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
    public class ReviewService : IReviewService
    {
        private readonly IDeleteRepository<Review> _deleteRepository;
        private readonly IReadRepository<Review> _readRepository;
        private readonly ICreateRepository<Review> _createRepository;
        private readonly IUpdateRepository<Review> _updateRepository;
        private readonly IMapper _mapper;
        public ReviewService(
            IDeleteRepository<Review> deleteRepository,
            IReadRepository<Review> readRepository,
            ICreateRepository<Review> createRepository,
            IUpdateRepository<Review> updateRepository
        ) {
            _deleteRepository = deleteRepository;
            _readRepository = readRepository;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
        }
        public ReviewService(IMapper mapper) => _mapper = mapper;

        public async Task<Review> CreateAsync(ReviewDTO reviewDTO)
        {
            reviewDTO.ReviewId = Guid.NewGuid().ToString();
            Review review = _mapper.Map<ReviewDTO, Review>(reviewDTO);

            return await _createRepository.CreateAsync(review);
        }

        public async Task DeleteAsync(ReviewDTO reviewDTO)
        {
            Review review = _mapper.Map<ReviewDTO, Review>(reviewDTO);
            if (String.IsNullOrEmpty(review.ReviewId))
                throw new ArgumentException("Cant find the review.");

            await _deleteRepository.DeleteAsync(review);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _readRepository.GetAllAsync().ToListAsync();
        }

        public async Task<Review> GetByIdAsync(ReviewDTO reviewDTO)
        {
            Review review = _mapper.Map<ReviewDTO, Review>(reviewDTO);
            if (String.IsNullOrEmpty(review.ReviewId))
                throw new ArgumentException("Cant find the review.");

            return ((review = await _readRepository.GetAllAsync().FirstOrDefaultAsync(p => p.ReviewId == review.ReviewId)) == null) ? throw new ArgumentException("Cant find the review.") : review;
        }

        public async Task<Review> UpdateAsync(ReviewDTO reviewDTO, string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("Id is empty");

            Review review = _mapper.Map<ReviewDTO, Review>(reviewDTO);
            ReviewDTO newReviewDTO = new ReviewDTO();
            newReviewDTO.ReviewId = id;
            Review reviewOld = await GetByIdAsync(newReviewDTO);
            reviewOld = review;
            reviewOld.ReviewId = id;
            return await _updateRepository.UpdateAsync(reviewOld);
        }
    }
}
