using System.Linq;
using Marvelist.DataAccess.Contracts;
using Marvelist.DataAccess.Repositories;
using Marvelist.Entities;

namespace Marvelist.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public ApplicationUser RegisterUser(ApplicationUser user)
        {
            user = _userRepository.Add(user);
            SaveChanges();
            return user;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            var user = _userRepository.GetMany(u => u.Email == email).FirstOrDefault();
            return user;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }

    public interface IUserService
    {
        ApplicationUser GetUserByEmail(string email);
        ApplicationUser RegisterUser(ApplicationUser user);

    }
}