using CarstoreApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Car_Application;
using DominC.Model;
using System.Diagnostics;

namespace CarstoreApi.Controllers
{
    using CarstoreApi.Implementations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    //تحديد من يمكنه الوصول الى هذا الكونترولر
    [Authorize(Roles = "User")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        /// <summary>
        /// controller by car 
        /// return true
        /// </summary>
        // إعداد الكنترولر باستخدام الواجهةالعامة
        private readonly IGenericRepository<Car> _carRepository;

        public CarsController(IGenericRepository<Car> cargen)
        {
            _carRepository = cargen;
        }
        //صلاحية وصول دون الحاجة الى المصادقة 
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllAsync()
        {
            var car = await _carRepository.GetAllAsync();
            if (car == null) return NotFound();
            return Ok(car);
        }

        [AllowAnonymous]
        [HttpGet("{id}" , Name = "GetCarById")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
           var car = await _carRepository.GetById(id);
            //التحقق مما إذا كان هناك بيانات 
            if (car == null) return NotFound();
            //إرجاع اجابة ناجحة مع قائمة في البيانات 
            return Ok(car);
        }
        //عملية إنشاء بناءً على البيانات المرسلة
        [HttpPost]
        public ActionResult<Car> Create(Car car)
        {  //إنشاء باستخدام الواجهة العامة
            var newCar = _carRepository.Create(car);
            //التحقق من نجاح الانشاء وإرجاع اجابة مناسبة بحسب الحالة ناجحة او لا
            if (newCar == null) return BadRequest();
            return CreatedAtRoute("GetCarById", new { newCar.Id }, newCar);
        }
        //عملية تحديث البيانات
        [HttpPut("{id}")]
        public ActionResult<Car> Update(int id,Car car)
        {
            //التحقق من مطابقة ال id المطلوب بوجوده ضمن قاعدة البيانات وإرجاع رد مناسب 

            if (id != car.Id) return BadRequest();
            _carRepository.Update(id,car);
            return NoContent();
        }
        //عملية حذف البيانات 
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            _carRepository.Delete(id);
            return NoContent();
        }
    }  
    //************************يمكن تعميم التعليقات السابقة على جميع الكونترولرات*****************
}
