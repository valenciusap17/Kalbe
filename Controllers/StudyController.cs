using AutoMapper;
using Kalbe.DTO;
using Kalbe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kalbe.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        private IMapper _mapper;
        protected ApplicationDbContext _repositoryContext;

        public StudyController(IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _repositoryContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAllvalue()
        { 
            return Ok(new string[] { "lala","lili"});
        }

        [HttpPost]
        public IActionResult PostStudyStatus([FromBody] PostStudyStatusDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("RefKriteriaVerifikasi object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("RefKriteriaVerifikasi object is not valid");
                }
                var postObject = _mapper.Map<m_study_status>(dto);
                _repositoryContext.m_study_status.Add(postObject);
                _repositoryContext.SaveChanges();
                return Ok(postObject);
            } catch (Exception ex)
            {
                return StatusCode(500, $"The error message is {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostMolecules([FromBody] PostMoleculesDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("RefKriteriaVerifikasi object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("RefKriteriaVerifikasi object is not valid");
                }
                var postObject = _mapper.Map<m_molecules>(dto);
                _repositoryContext.m_molecules.Add(postObject);
                _repositoryContext.SaveChanges();
                return Ok(postObject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"The error message is {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostStudy([FromBody] PostStudyDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("RefKriteriaVerifikasi object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("RefKriteriaVerifikasi object is not valid");
                }
                var postObject = _mapper.Map<m_study>(dto);
                _repositoryContext.m_study.Add(postObject);
                _repositoryContext.SaveChanges();
                return Ok(postObject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"The error message is {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllStudyStatus()
        {
            try
            {
                var result = _repositoryContext.m_study_status.AsNoTracking().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"The error message is {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllMolecules()
        {
            try
            {
                var result = _repositoryContext.m_molecules.AsNoTracking();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"The error message is {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllStudy()
        {
            try
            {
                var result = _repositoryContext.m_study
                .Include(h => h.Molecule)
                .Include(h => h.StudyStatus)
                .Select( h =>  new StudiesCardDto {
                    Id = h.Id,
                    ProtocolTitle = h.ProtocolTitle,
                    MoleculesName = h.Molecule.MoleculesName,
                    MolDescription = h.Molecule.MolDescription,
                    StatusName = h.StudyStatus.StatusName,
                    CreatedBy = h.CreatedBy,
                    CreatedDate = h.CreatedDate,
                    UpdatedBy = h.UpdatedBy,
                    UpdatedDate = h.UpdatedDate
                })
                .AsNoTracking();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"The error message is {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditStudy(Guid id, [FromBody] EditStudyDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("RefKriteriaVerifikasi object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("RefKriteriaVerifikasi object is not valid");
                }
                var currentObject = _repositoryContext.m_study.Where(h => h.Id.Equals(id)).FirstOrDefault();
                if (currentObject == null)
                {
                    return BadRequest("Object not found");
                }

                _mapper.Map(dto, currentObject);
                _repositoryContext.m_study.Update(currentObject);

                _repositoryContext.SaveChanges();

                return Ok(currentObject);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"The error message is: {e.Message}");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult RemoveStudy(Guid id)
        {
            try
            {
                var currentObject = _repositoryContext.m_study.Where(h => h.Id.Equals(id)).FirstOrDefault();
                if (currentObject == null)
                {
                    return BadRequest("Object not found");
                }

                currentObject.IsDeleted = true;
                currentObject.IsActive = false;
                _repositoryContext.m_study.Update(currentObject);

                _repositoryContext.SaveChanges();

                return Ok(currentObject);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"The error message is: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudy(Guid id)
        {
            try
            {
                var currentObject = _repositoryContext.m_study.Where(h => h.Id.Equals(id)).FirstOrDefault();
                if (currentObject == null)
                {
                    return BadRequest("Object not found");
                }

                _repositoryContext.m_study.Remove(currentObject);

                _repositoryContext.SaveChanges();

                return Ok(currentObject);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"The error message is: {e.Message}");
            }
        }
    }
}
