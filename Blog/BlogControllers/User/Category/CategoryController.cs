using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Blog.Service;
using Blog.Helper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.BlogControllers.User.Category
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

        //public CategoryController(ICategoryService<string> categoryService)
        //{
            //this._categoryService = categoryService;
        //}

        /**
         * 
         * 获取当前用户的文章分类列表
         * 
         */
        [Route(UrlPrefix + "/{userid}/categories")]
        [HttpGet]
        public ActionResult<List<Blog.JSONEntity.Category>> GetCategories(string userid)
        {
            if (userid == null)
            {
                return BadRequest();
            }              
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
        [Route(UrlPrefix + "/{userid}/category/{id}")]
        [HttpGet]
        public ActionResult<Blog.JSONEntity.Category> GetCategory(string userid, int? id)
        {
            if(userid == null || id == null)
            {
                return BadRequest();
            }
            Blog.JSONEntity.Category category = null;
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

            JSONEntity.Category category = new JSONEntity.Category((int)id, newdisplayname);

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

            JSONEntity.Category category = new JSONEntity.Category((int)id, newdisplayname);

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
        public ActionResult<JSONEntity.Category> AddCategory(JSONEntity.Category category,string userid)
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