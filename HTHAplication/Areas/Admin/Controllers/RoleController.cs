using HTHAplication.Common;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTHAplication.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Admin/Role
        [HasCredential(RoleID = "VIEW_ROLE")]
        public ActionResult Index()
        {
            return View();
        }

        [HasCredential(RoleID = "VIEW_ROLE")]
        public JsonResult GetRoles(string sord, int page, int rows, string searchString)
        {
            //#1 Create Instance of DatabaseContext class for Accessing Database.  

            //#2 Setting Paging  
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var db = new RoleDao();
            //#3 Linq Query to Get Customer   
            var Results = db.GetAll();

            //#4 Get Total Row Count  
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            //#5 Setting Sorting  
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.ID);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.ID);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            //#6 Setting Search  
            if (!string.IsNullOrEmpty(searchString))
            {
                Results = Results.Where(m => m.Name.Contains(searchString)).ToList();
            }
            //#7 Sending Json Object to View.  
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        [HasCredential(RoleID = "CREATE_ROLE")]
        [HttpPost]
        public JsonResult Create(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new RoleDao();
                    var result = dao.Insert(role);
                    if (result == 1)
                    {
                        SetAlert("Thêm bản ghi thành công!", "success");
                        return Json("Saved Successfully!", JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        SetAlert("Không thể thêm bản ghi này!", "error");
                        return Json("Not Saved!", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var errorList = (from item in ModelState
                                     where item.Value.Errors.Any()
                                     select item.Value.Errors[0].ErrorMessage).ToList();
                    SetAlert("Not Saved!", "error");
                    return Json(errorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                SetAlert("Không thể thêm bản ghi này!", "error");
                var errormessage = "Error occured: " + ex.Message;
                return Json(errormessage, JsonRequestBehavior.AllowGet);
            }

        }
        [HasCredential(RoleID = "EDIT_ROLE")]
        [HttpPost]
        public string Edit(Role role)
        {
            string msg = "Done";
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new RoleDao();
                    var result = dao.Update(role);
                    if (result == 1)
                    {
                        SetAlert("Thêm bản ghi thành công!", "success");
                        msg = "Saved Successfully";
                    }
                    else
                    {
                        msg = "Some Validation ";
                        SetAlert("Không thể thêm bản ghi này!", "error");
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                SetAlert("Không thể thêm bản ghi này!", "error");
            }
            return msg;
        }
        [HasCredential(RoleID = "DELETE_ROLE")]
        [HttpPost]
        public string Delete(string Id)
        {
            var dao = new RoleDao();
            var result = dao.Delete(Id);
            if (result == 1)
            {
                SetAlert("Thêm bản ghi thành công!", "success");
                return "Deleted successfully";
            }
            else
            {
                SetAlert("Không thể thêm bản ghi này!", "error");
                return "Some Validation ";
            }
        }

    }
}