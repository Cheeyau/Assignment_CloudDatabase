using AutoMapper;
using Domain;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IDeleteRepository<User> _deleteRepository;
        private readonly IReadRepository<User> _readRepository;
        private readonly ICreateRepository<User> _createRepository;
        private readonly IUpdateRepository<User> _updateRepository;
        private readonly IMapper _mapper;
        public UserService(
            IDeleteRepository<User> deleteRepository, 
            IReadRepository<User> readRepository, 
            ICreateRepository<User> createRepository, 
            IUpdateRepository<User> updateRepository
        ) {
            _deleteRepository = deleteRepository;
            _readRepository = readRepository;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
        }
        public UserService(IMapper mapper) => _mapper = mapper;
        public async Task<User> CreateAsync(UserDTO UserDTO)
        {
            UserDTO.UserId = Guid.NewGuid().ToString();
            User user = _mapper.Map<UserDTO, User>(UserDTO);

            return await _createRepository.CreateAsync(user);
        }

        public async Task DeleteAsync(UserDTO UserDTO)
        {
            User user = _mapper.Map<UserDTO, User>(UserDTO);
            if (String.IsNullOrEmpty(user.UserId))
                throw new ArgumentException("Cant find the order.");

            await _deleteRepository.DeleteAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _readRepository.GetAllAsync().ToListAsync();
        }

        public async Task<User> GetByIdAsync(UserDTO UserDTO)
        {
            User user = _mapper.Map<UserDTO, User>(UserDTO);
            if (String.IsNullOrEmpty(user.UserId))
                throw new ArgumentException("Cant find the order.");

            return ((user = await _readRepository.GetAllAsync().FirstOrDefaultAsync(p => p.UserId == user.UserId)) == null) ? user = new() : user;
        }

        public async Task<User> UpdateAsync(UserDTO UserDTO, string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("Id is empty");

            User user = _mapper.Map<UserDTO, User>(UserDTO);
            UserDTO newUserDTO = new();
            newUserDTO.UserId = id;
            User userOld = await GetByIdAsync(newUserDTO);
            userOld = user;
            return await _updateRepository.UpdateAsync(userOld);
        }
    }
}
