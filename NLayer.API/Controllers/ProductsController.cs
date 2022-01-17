using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Dtos;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _productService;

        public ProductsController(IMapper mapper, IService<Product> productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsnyc(_mapper.Map<Product>(productDto));
            var newProductDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, newProductDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _productService.UpdateAsnyc(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsnyc(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
