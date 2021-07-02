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
    public class DeTaisController : ControllerBase
    {
        private IDeTaiBLL _DeTaiBLL;
        public DeTaisController(IDeTaiBLL DeTaiBLL)
        {
            _DeTaiBLL = DeTaiBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DeTaiModel> GetDataAll()
        {
            return _DeTaiBLL.GetData();
        }

        [Route("get-them-cuoi")]
        [HttpGet]
        public DeTaiModel GetThemCuoi()
        {
            return _DeTaiBLL.GetTopCuoi();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public DeTaiModel GetDatabyID(int id)
        {
            return _DeTaiBLL.GetDatabyID(id);
        }

        [Route("get-by-gv/{id}")]
        [HttpGet]
        public IEnumerable<DeTaiModel> GetDatabyGV(int id)
        {
            return _DeTaiBLL.GetDatabyGV(id);
        }

        [Route("get-by-vitri")]
        [HttpPost]
        public SoHuuDTModel GetDatabyVT([FromBody] Dictionary<string, object> formData)
        {
            var idDT = int.Parse(formData["idDT"].ToString());
            string idGV = Convert.ToString(formData["idGV"]); 
            var data = _DeTaiBLL.GetDatabyVT(idDT, idGV);
            return data;
        }

        [Route("create-detai")]
        [HttpPost]
        public DeTaiModel CreateItem([FromBody] DeTaiModel model)
        {
            _DeTaiBLL.Create(model);
            return model;
        }

        [Route("create-gv-detai")]
        [HttpPost]
        public SoHuuDTModel Create_GV_DT([FromBody] SoHuuDTModel model)
        {
            _DeTaiBLL.CreateGV(model);
            return model;
        }

        [Route("delete-detai")]
        [HttpPost]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            int id = 0;
            if (formData.Keys.Contains("id") && Convert.ToInt32(formData["id"].ToString()) > 0)
            { id = Convert.ToInt32(formData["id"].ToString()); }
            _DeTaiBLL.Delete(id);
            return Ok();
        }

        [Route("delete-gv-detai")]
        [HttpPost]
        public IActionResult DeleteGV([FromBody] Dictionary<string, object> formData)
        {
            var idDT = int.Parse(formData["idDT"].ToString());
            string idGV = Convert.ToString(formData["idGV"]);
            _DeTaiBLL.DeleteGV(idDT,idGV);
            return Ok();
        }

        [Route("update-detai")]
        [HttpPost]
        public DeTaiModel UpdateUser([FromBody] DeTaiModel model)
        {
            _DeTaiBLL.Update(model);
            return model;
        }

        [Route("update-gv-detai")]
        [HttpPost]
        public SoHuuDTModel UpdateGV([FromBody] SoHuuDTModel model)
        {
            _DeTaiBLL.UpdateGV(model);
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
                string idGV = "";
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
                {
                    ten = Convert.ToString(formData["ten"]); 
                }
                if (formData.Keys.Contains("idGV") && !string.IsNullOrEmpty(Convert.ToString(formData["idGV"])))
                {
                    idGV = Convert.ToString(formData["idGV"]);
                }
                long total = 0;
                var data = _DeTaiBLL.Search(page, pageSize, out total, ten, idGV);
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

        [Route("search-ds")]
        [HttpPost]
        public ResponseModel SearchDS([FromBody] Dictionary<string, object> formData)
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
                var data = _DeTaiBLL.Search(page, pageSize, out total, ten);
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

        [Route("detai-gv-vitri")]
        [HttpPost]
        public IEnumerable<DeTaiModel> DeTaiGV_ViTri([FromBody] Dictionary<string, object> formData)
        {
            string id = Convert.ToString(formData["Id"]);
            string vitri = Convert.ToString(formData["vitri"]);
            var data=   _DeTaiBLL.DTGV_ViTri(id, vitri);
            return data ;


        }

        [Route("tongsl")]
        [HttpGet]
        public int laytong()
        {
            return _DeTaiBLL.GetTong();
        }

        //[Route("tk-nam")]
        //[HttpPost]
        //public IEnumerable<DeTaiModel> TK_Nam([FromBody] Dictionary<string, object> formData)
        //{
        //    int nam = int.Parse(formData["nam"].ToString());
        //    bool trangthai = bool.Parse(formData["trangthai"].ToString()); ;
        //    //if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
        //    //{
        //    //    nam = int.Parse(formData["nam"].ToString());
        //    //}

        //    //if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
        //    //{
        //    //    trangthai = bool.Parse(formData["nam"].ToString());
        //    //}
        //    var data = _DeTaiBLL.TK_Nam(nam, trangthai);
        //    return data;
        //}
    }
}
