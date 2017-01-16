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


        public ApplicationUser GetById(string id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public ApplicationUser RegisterUser(ApplicationUser user)
        {
            user = _userRepository.Add(user);
            SaveChanges();
            return user;
        }

        public ApplicationUser GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return user;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

    }

    public interface IUserService
    {
        ApplicationUser GetByEmail(string email);
        ApplicationUser GetById(string id);
        ApplicationUser RegisterUser(ApplicationUser user);

    }
}