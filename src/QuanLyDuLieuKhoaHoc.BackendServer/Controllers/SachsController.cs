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
    public class SachsController : ControllerBase
    {
        private ISachBLL _SachBLL;
        public SachsController(ISachBLL SachBLL)
        {
            _SachBLL = SachBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SachModel> GetDataAll()
        {
            return _SachBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SachModel GetDatabyID(string id)
        {
            return _SachBLL.GetDatabyID(id);
        }

        [Route("get-by-gv/{id}")]
        [HttpGet]
        public IEnumerable<SachModel> GetDatabyGV(int id)
        {
            return _SachBLL.GetDatabyGV(id);
        }

        [Route("create-Sach")]
        [HttpPost]
        public SachModel CreateItem([FromBody] SachModel model)
        {
            _SachBLL.Create(model);
            return model;
        }

        [Route("delete-Sach")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string Id = "";
            if (formData.Keys.Contains("Id") && !string.IsNullOrEmpty(Convert.ToString(formData["Id"]))) 
            { Id = Convert.ToString(formData["Id"]); }
            _SachBLL.Delete(Id);
            return Ok();
        }

        [Route("update-Sach")]
        [HttpPost]
        public SachModel UpdateUser([FromBody] SachModel model)
        {
            _SachBLL.Update(model);
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
                string idGV = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
                {
                    ten = Convert.ToString(formData["ten"]);
                }
                if (formData.Keys.Contains("idGV") && !string.IsNullOrEmpty(Convert.ToString(formData["idGV"])))
                {
                    idGV = Convert.ToString(formData["idGV"]);
                }
                long total = 0;
                var data = _SachBLL.Search(page, pageSize, out total, ten, idGV);
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

        [Route("loai-sach")]
        [HttpPost]
        public IEnumerable<SachModel> DeTaiGV_ViTri([FromBody] Dictionary<string, object> formData)
        {
            string id = Convert.ToString(formData["Id"]);
            string loai = Convert.ToString(formData["LoaiSach"]);
            var data = _SachBLL.SGV_ViTri(id, loai);
            return data;


        }

        [Route("tongsl")]
        [HttpGet]
        public int laytong()
        {
            return _SachBLL.GetTong();
        }
    }
}
