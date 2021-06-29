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
    public class DaoTaosController : ControllerBase
    {
        private IDaoTaoBLL _DaoTaoBLL;
        public DaoTaosController(IDaoTaoBLL DaoTaoBLL)
        {
            _DaoTaoBLL = DaoTaoBLL;
        }

        [Route("get-all/{id}")]
        [HttpGet]
        public IEnumerable<DaoTaoModel> GetDataAll_GV(string id)
        {
            return _DaoTaoBLL.GetData_GV(id);
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DaoTaoModel GetDatabyID(string id)
        {
            return _DaoTaoBLL.GetDatabyID(id);
        }
        [Route("create-daotao")]
        [HttpPost]
        public DaoTaoModel CreateItem([FromBody] DaoTaoModel model)
        {
            _DaoTaoBLL.Create(model);
            return model;
        }

        [Route("delete-daotao")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string dt_id = "";
            if (formData.Keys.Contains("dt_id") && !string.IsNullOrEmpty(Convert.ToString(formData["dt_id"]))) { dt_id = Convert.ToString(formData["dt_id"]); }
            _DaoTaoBLL.Delete(dt_id);
            return Ok();
        }

        [Route("update-daotao")]
        [HttpPost]
        public DaoTaoModel UpdateUser([FromBody] DaoTaoModel model)
        {
            _DaoTaoBLL.Update(model);
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
                string idGV = Convert.ToString(formData["idGV"]);
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
                {
                    ten = Convert.ToString(formData["ten"]);
                }
                long total = 0;
                var data = _DaoTaoBLL.Search(page, pageSize, out total, ten,idGV);
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
        public List<DaoTaoModel> GetGV(string id)
        {
            return _DaoTaoBLL.GetGV(id);
        }


        //Ngoại ngữ
        
        [Route("get-ngoaingu-gv/{id}")]
        [HttpGet]
        public List<NgoaiNguModel> GetNNGV(string id)
        {
            return _DaoTaoBLL.Get_NgoaiNgu_GV(id);
        }
    }
}
