using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Blog.Service;

namespace Blog.BlogControllers.User.Category
{
    /**
     *  当前用户的文章分类接口
     *
     */
    //[Route("/blog")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService<string> _categoryService;

        public CategoryController(ICategoryService<string> categoryService)
        {
            this._categoryService = categoryService;
        }

        /**
         * 
         * 获取当前用户的文章分类列表
         * 
         */
        [HttpGet("user/{userid}/categories")]
        [ProducesResponseType(typeof(List<Blog.JSONEntity.Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Blog.JSONEntity.Category>> GetCategories(string userid)
        {
            List<Blog.JSONEntity.Category> categories = null;
            categories = _categoryService.GetCategories(userid);
            if(categories == null)
            {
                return NotFound();
            }
            return categories;
        }

        /**
         * 
         * 获取当前用户的某个分类
         * 
         */
        [HttpGet("/user/{userid}/category/{id}")]
        [ProducesResponseType(typeof(JSONEntity.Category),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Blog.JSONEntity.Category> GetCategory(string userid, int id)
        {
            Blog.JSONEntity.Category category = null;
            category = _categoryService.GetCategory(userid, id);
            if(category == null)
            {
                return NotFound();
            }
            return category;
        }

        /**
         * 
         * 更新当前用户的某个列表
         * 
         */
        [HttpPut("/user/{userid}/category/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(List<JSONEntity.Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<JSONEntity.Category>> UpdateCategory(string userid,JSONEntity.Category category)
        {
            if (_categoryService.Replace(userid,category))
            {
                return _categoryService.GetCategories(userid);
            }
            else
            {
                return Forbid();
            }
        }

        /**
         * 
         * 删除当前用户添加一个分类项
         * 
         */
        [HttpDelete("/user/{userid}/category/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCategory(string userid, JSONEntity.Category category)       
        {
            if (_categoryService.Delete(userid, category))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        /**
         * 
         * 更新当前用户的一个分类项
         * 
         */
        [HttpPost("/user/{userid}/categories")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JSONEntity.Category> AddCategory(string userid,JSONEntity.Category category)
        {
            if (_categoryService.Add(userid, category))
            {
                return _categoryService.GetCategory(userid, category.Id);
            }
            return NotFound();
        }
    }
}