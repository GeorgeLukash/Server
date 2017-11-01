﻿using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Enums;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.SecurityContext.Abstraction;
using System;
using System.Linq;

namespace FitnessTracker.Operations.Implementation
{
    public class AuthenticationOperations : IAuthenticationOperations
    {
        private readonly ICrypthographyContext _cryptographyContext;
        private readonly IPasswordContext _passwordContext;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationOperations(IUnitOfWork uow, ICrypthographyContext crypto, IPasswordContext password)
        {
            _unitOfWork = uow;
            _cryptographyContext = crypto;
            _passwordContext = password;
        }

        public UserModel FindUser(string username, string password)
        {
            var user = _unitOfWork.Repository<UserEntity>().Set.FirstOrDefault(x => x.Email == username);
            return user == null || !_passwordContext.ArePasswordsEqual(password, user.Password, user.Salt) ? null : new UserModel
            {
                Email = user.Email,
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                UserType = user.Role
            };
        }

        public UserModel RegisterUser(AuthenticationModel user)
        {
            if (_unitOfWork.Repository<UserEntity>().Set.FirstOrDefault(x => x.Email == user.Email) != null)
            {
                throw new InvalidOperationException("User already exists");
            }

            byte[] salt = _cryptographyContext.GenerateRandomBytes();
            byte[] encode = _passwordContext.EncodePassword(user.Password, salt);

            var userEntity = new UserEntity
            {
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Password = Convert.ToBase64String(encode),
                Salt = Convert.ToBase64String(salt),
                Role = (int)UserType.User,
                Profile = new UserProfileEntity
                {
                    Age = user.Age,
                    Height = user.Height,
                    Sex = user.Sex,
                    Weight = user.Weight
                }
            };
            _unitOfWork.Repository<UserEntity>().Insert(userEntity);
            _unitOfWork.SaveChanges();

            return new UserModel
            {
                Email = userEntity.Email,
                Id = userEntity.Id,
                Firstname = userEntity.Firstname,
                Lastname = userEntity.Lastname,
                UserType = userEntity.Role
            };

        }
    }
}