using Business.Abstract;
using Business.Constants;

using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;

using Entities.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private ISysLog _sysLog;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ISysLog sysLog)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _sysLog = sysLog;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            SysLog sysLogs = new SysLog { LogContent = "Token Has Created for " + user.Email, LogDate = DateTime.Now };
            _sysLog.Add(sysLogs);
            return new SuccessDataResult<AccessToken>(accessToken, "Access Token Created");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            SysLog sysLogs = new SysLog { LogContent = "This UseR: " + userForLoginDto.Email + " has loggin the system", LogDate = DateTime.Now };
            _sysLog.Add(sysLogs);
            return new SuccessDataResult<User>(userToCheck, Messages.LoginSuccessfull);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            SysLog sysLogs = new SysLog { LogContent = "This User has registered the system: " + user.Email, LogDate = DateTime.Now };
            _sysLog.Add(sysLogs);
            return new SuccessDataResult<User>(user, Messages.UserRegisterSuccess);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult("Not Exist!");
        }
    }
}
