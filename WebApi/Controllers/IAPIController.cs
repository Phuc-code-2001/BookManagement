using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public interface IAPIController<CreateModel, UpdateModel>
    {
        public IActionResult GetAll();
        public IActionResult Get(int Id);
        public IActionResult Create(CreateModel createModel);
        public IActionResult Update(UpdateModel updateModel);
        public IActionResult Delete(int Id);

    }
}
