using System.Runtime.InteropServices;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Kalbe.DTO;
using Kalbe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kalbe.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/[controller]/[action]")]
    public class StudyViewController : Controller
    {
        private readonly HttpClient _httpclient;
        private readonly IMapper _mapper;
        private readonly ILogger<StudyViewController> _logger;

        public StudyViewController(IHttpClientFactory httpClientFactory, IMapper mapper, ILogger<StudyViewController> logger) {
            this._httpclient = httpClientFactory.CreateClient();
            this._mapper = mapper;
            this._logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var StudiesResponse = await _httpclient.GetAsync("http://localhost:5099/api/Study/getAllStudy");
            var StudyStatusResponse = await _httpclient.GetAsync("http://localhost:5099/api/Study/getAllStudyStatus");
            var MoleculesResponse = await _httpclient.GetAsync("http://localhost:5099/api/Study/getAllMolecules");

            if (StudiesResponse.IsSuccessStatusCode && StudyStatusResponse.IsSuccessStatusCode & MoleculesResponse.IsSuccessStatusCode ) {
                var StudiesJsonString = await StudiesResponse.Content.ReadAsStringAsync();
                var StudyStatusJsonString = await StudyStatusResponse.Content.ReadAsStringAsync();
                var MoleculesJsonString = await MoleculesResponse.Content.ReadAsStringAsync();
                var queryData = new HomePageDto {};
                var StudiesTemp = JsonConvert.DeserializeObject<List<StudiesCardDto>>(StudiesJsonString);
                _logger.LogInformation("StudiesTemp: {@StudiesTemp}", StudiesTemp);
                if (StudiesTemp != null) {
                    queryData.Studies = StudiesTemp;
                }
                var StudyStatusTemp =  JsonConvert.DeserializeObject<List<m_study_status>>(StudyStatusJsonString);
                if (StudyStatusTemp != null) {
                    queryData.StudyStatus = StudyStatusTemp;
                }
                var MoleculesTemp =  JsonConvert.DeserializeObject<List<m_molecules>>(MoleculesJsonString);
                if (MoleculesTemp != null) {
                    var temp = _mapper.Map<List<m_molecules>, List<MoleculesSelectDto>>(MoleculesTemp);
                    queryData.Molecules = temp;
                }
                return View(queryData);
            }
            return View("Error");  
        }

    }
}
