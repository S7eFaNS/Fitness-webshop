using ClassLibrary.Classes.User;
using Database.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class UserManager : IUserManager 
    {
        private UserRepository repository = new();

        public List<User> GetAllUsers()
        {
            List<User> users = repository.GetUsers();
            return users;
        }

        public bool DeleteUser(User user)
        {
            if (repository.DeleteUser(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Create(UserViewModel viewModel)
        {
            User record = Helpers.MapToEntity<UserViewModel, User>(viewModel);
            repository.Create(record);
        }

        public UserViewModel FindById(int id)
        {
            User? record = repository.Read(id);
            if (record == null) throw new Exception($"Animal with id {id} is not found");
            return Helpers.MapToModel<User, UserViewModel>(record);
        }

        public IEnumerable<UserViewModel> FindAll()
        {
            return repository.ReadAll().Select(record => Helpers.MapToModel<User, UserViewModel>(record));
        }

        public IEnumerable<UserViewModel> FindAllByName(string name)
        {
            return repository.ReadAll(name).Select(record => Helpers.MapToModel<User, UserViewModel>(record));
        }

        public void FindAndUpdate(UserViewModel viewModel, string? firstName = null, string? lastName = null, string? password = null)
        {
            if (firstName != null)
            {
                viewModel.FirstName = firstName;
            }
            if (lastName != null)
            {
                viewModel.LastName = lastName;
            }
            if (password != null)
            {
                viewModel.Password = password;
            }
            User entity = Helpers.MapToEntity<UserViewModel, User>(viewModel);
            repository.Update(entity);
        }
        public void FindByIdAndDelete(int id)
        {
            repository.Delete(id);
        }
    }
}
