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
    public class KhoaDaoTaosController : ControllerBase
    {
        private IKhoaDaoTaoBLL _KhoaDaoTaoBLL;
        public KhoaDaoTaosController(IKhoaDaoTaoBLL KhoaDaoTaoBLL)
        {
            _KhoaDaoTaoBLL = KhoaDaoTaoBLL;
        }

        [Route("get-all/{id}")]
        [HttpGet]
        public IEnumerable<KhoaDaoTaoModel> GetDatabAll_GV(string id)
        {
            return _KhoaDaoTaoBLL.GetData_GV(id);
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public KhoaDaoTaoModel GetDatabyID(string id)
        {
            return _KhoaDaoTaoBLL.GetDatabyID(id);
        }
        [Route("create-daotao")]
        [HttpPost]
        public KhoaDaoTaoModel CreateItem([FromBody] KhoaDaoTaoModel model)
        {
            _KhoaDaoTaoBLL.Create(model);
            return model;
        }

        [Route("delete-daotao")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string dt_id = "";
            if (formData.Keys.Contains("dt_id") && !string.IsNullOrEmpty(Convert.ToString(formData["dt_id"]))) { dt_id = Convert.ToString(formData["dt_id"]); }
            _KhoaDaoTaoBLL.Delete(dt_id);
            return Ok();
        }

        [Route("update-daotao")]
        [HttpPost]
        public KhoaDaoTaoModel UpdateUser([FromBody] KhoaDaoTaoModel model)
        {
            _KhoaDaoTaoBLL.Update(model);
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
                var data = _KhoaDaoTaoBLL.Search(page, pageSize, out total, ten);
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
        [Route("get-gv/{id}")]
        [HttpGet]
        public List<KhoaDaoTaoModel> GetGV(string id)
        {
            return _KhoaDaoTaoBLL.GetGV(id);
        }
    }
}
