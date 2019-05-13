using Blog.Helper;
using Blog.JSONEntity;
using Blog.Service;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog.BlogControllers.User.CategoryController
{
    /**
     *  当前用户的文章分类接口
     *
     */
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private const string UrlPrefix = "/user";

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
        [Route(UrlPrefix + "/{userid}/categories")]
        [HttpGet]
        public ActionResult<List<CategoryJSON>> GetCategories(string userid)
        {
            if (userid == null)
            {
                return BadRequest();
            }              
            List<CategoryJSON> categories = null;
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
        [Route(UrlPrefix + "/{userid}/category/{id}")]
        [HttpGet]
        public ActionResult<CategoryJSON> GetCategory(string userid, int? id)
        {
            if(userid == null || id == null)
            {
                return BadRequest();
            }
            CategoryJSON category = null;
            category = _categoryService.GetCategory(userid, (int)id);
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
        [Route(UrlPrefix + "/{userid}/category/{id}")]
        [HttpPut]
        [Authorize]
        public ActionResult UpdateCategory(string userid,int? id,string newdisplayname)
        {            
            if(userid==null||id==null||newdisplayname ==null)
            {
                return BadRequest();
            }

            CategoryJSON category = new CategoryJSON((int)id, newdisplayname);

            Resultion resultion = _categoryService.Replace(userid, category);
            if (resultion.IsSuccess)
            {
                return CreatedAtAction(nameof(UpdateCategory), resultion.Value);
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
        [Route(UrlPrefix + "/{userid}/category/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteCategory(string userid, int? id, string newdisplayname)
        {
            if (userid == null || id == null || newdisplayname == null)
            {
                return BadRequest();
            }

            CategoryJSON category = new CategoryJSON((int)id, newdisplayname);

            Resultion resultion = _categoryService.Delete(userid, category);
            if (resultion.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();       
        }

        /**
         * 
         * 更新当前用户的一个分类项
         * 
         */
        [Route(UrlPrefix+"/{userid}/categories")]
        [HttpPost]
        [Authorize]
        public ActionResult<JSONEntity.CategoryJSON> AddCategory(JSONEntity.CategoryJSON category,string userid)
        {          
            if (category == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            
            Resultion resultion = _categoryService.Add(userid, category);

            if (resultion.IsSuccess)
            {
                return CreatedAtAction(nameof(AddCategory), resultion.Value);
            }   
            return NotFound();
            
        }
    }
}