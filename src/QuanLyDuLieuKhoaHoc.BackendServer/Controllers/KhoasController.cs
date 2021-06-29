using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyDuLieuKhoaHoc.BLL;
using QuanLyDuLieuKhoaHoc.Model;

namespace QuanLyDuLieuKhoaHoc.BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoasController : ControllerBase
    {
        private IKhoaBLL _KhoaBLL;
        public KhoasController(IKhoaBLL KhoaBLL)
        {
            _KhoaBLL = KhoaBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<KhoaModel> GetDataAll()
        {
            return _KhoaBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public KhoaModel GetDatabyID(string id)
        {
            return _KhoaBLL.GetDatabyID(id);
        }

        [Route("create-Khoa")]
        [HttpPost]
        public KhoaModel CreateItem([FromBody] KhoaModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            _KhoaBLL.Create(model);
            return model;
        }

        [Route("delete-Khoa")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _KhoaBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-Khoa")]
        [HttpPost]
        public KhoaModel UpdateUser([FromBody] KhoaModel model)
        {
            _KhoaBLL.Update(model);
            return model;
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
                {
                    ten = Convert.ToString(formData["ten"]);
                }
                long total = 0;
                var data = _KhoaBLL.Search(page, pageSize, out total, ten);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
