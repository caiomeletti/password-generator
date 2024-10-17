using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PwdGen.API.ViewModels;
using PwdGen.Services.DTO;
using PwdGen.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PwdGen.API.Controllers
{
    [SwaggerTag("Segurança")]
    [Route("api/v1/securities")]
    [ApiController]

    public class SecurityController : Controller
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordservice;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="passwordservice"></param>
        public SecurityController(IMapper mapper,
            IPasswordService passwordservice)
        {
            _mapper = mapper;
            _passwordservice = passwordservice;
        }

        /// <summary>
        /// Gear uma senha de acordo com as características indicadas (comprimento e detalhes de segurança)
        /// </summary>
        /// <param name="createPasswordViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("passwords")]
        [ProducesResponseType(typeof(PasswordDTO), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] CreatePasswordViewModel createPasswordViewModel)
        {
            var pwdDTO = _mapper.Map<PasswordDTO>(createPasswordViewModel);
            var result = _passwordservice.Generate(pwdDTO);

            return Created(Request.Path, result);
        }
    }
}
