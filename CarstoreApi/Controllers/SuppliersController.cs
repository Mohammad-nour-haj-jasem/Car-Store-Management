using CarstoreApi.Implementations;
using CarstoreApi.Repositories;
using DominC.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //تحديد من يمكنه الوصول الى هذا الكونترولر
    [Authorize(Roles = "User")]
    public class SuppliersController : ControllerBase
    {
        private readonly IGenericRepository<Supplier> _supplierRepository;

        // إعداد الكنترولر باستخدام الواجهةالعامة

        public SuppliersController(IGenericRepository<Supplier> suppliergen)
        {
            _supplierRepository = suppliergen;
        }
        //صلاحية وصول دون الحاجة الى المصادقة 
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> GetAllAsync()
        {
            var supplier = await _supplierRepository.GetAllAsync();
            //التحقق مما إذا كان هناك بيانات 
            if (supplier == null) return NotFound();
            //إرجاع اجابة ناجحة مع قائمة في البيانات 
            return Ok(supplier);
        }
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetSupplierById")]
        public async Task<ActionResult<Supplier>> GetSupplierById(int id)
        {
            var supplier = await _supplierRepository.GetById(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }
        //عملية إنشاء بناءً على البيانات المرسلة
        [HttpPost]
        public ActionResult<Supplier> Create(Supplier supplier)
        {
            //إنشاء باستخدام الواجهة العامة
            var newSupplier = _supplierRepository.Create(supplier);
            //التحقق من نجاح الانشاء وإرجاع اجابة مناسبة بحسب الحالة ناجحة او لا
            if (newSupplier == null) return BadRequest();
            return CreatedAtRoute("GetSupplierById", new { newSupplier.Id }, newSupplier);
        }
        //عملية تحديث البيانات
        [HttpPut("{id}")]
        public ActionResult<Supplier> Update(int id, Supplier supplier)
        { 
            //التحقق من مطابقة ال id المطلوب بوجوده ضمن قاعدة البيانات وإرجاع رد مناسب 
            if (id != supplier.Id) return BadRequest();
            _supplierRepository.Update(id, supplier);
            return NoContent();
        }
        //عملية حذف بيانات
        [HttpDelete("{id}")]
        public ActionResult<Supplier> Delete(int id)
        {
            _supplierRepository.Delete(id);
            return NoContent();
        }
    }
}