using IUNRWA_DTOs.AreaDto;
using IUNRWA_DTOs.AreaPlaceDto;
using IUNRWA_DTOs.FamilyCardDto;
using IUNRWA_DTOs.PersonDto;
using IUNRWA_DTOs.ReservationDto;
using IUNRWA_DTOs.StudyLevelDto;
using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IUNRWA_DTOs.Views
{
    public class ClerickViewsDto
    {
        public FamilyCardDto.FamilyCardDto FamilyCardObject { get; set; } = new();
        public string FamilyCard { get; set; }
        public int PersonId { get; set; }

        public string ChildCardNumber { set; get; }
        public string NCDNumber { set; get; }
        public PersonDto.PersonDto PersonToUpdateDto { get; set; } = new();
        public PersonDto.PersonDto PersonInfo { get; set; } = new();

        public List<StudyLevelDto.StudyLevelDto> studyLevels { get; set; } = new();
        public List<AreaDto.AreaDto> Areas { get; set; } = new();
        public List<RelationshipDto.RelationshipDto> Relationships { get; set; } = new();
        public PersonFormDto PersonToUpdateFormDto { get; set; } = new();
        public ReservationFormDto ReservationFormDto { get; set; } = new();
        public ReservationFormDto ReservationUpdateFormDto { get; set; } = new();

        public List<TheServiceDto.TheServiceDto> Services { get; set; } = new();
        public List<TeamDto.TeamDto> Teams { get; set; } = new();

        public List<DoctorDto.DoctorDto> Doctors { get; set; } = new();

        public List<TimeSloteDto.TimeSloteDto> TimeSlotes { get; set; } = new();
        public List<ReservationDto.ReservationDto> AllPersonReservations { get; set; } = new();
        [Display(Name = "Team")]
        public int TeamId { get; set; }
        [Display(Name = "Team")]
        public int TeamIdQuick { get; set; }
        public int TeamIdEdit { get; set; }

        public int ReservationId { get; set; }
        public int ReservationToEditId { get; set; }

        #region Ajax parameters
        [Display(Name = "Provider")]
        public int AjaxDoctorByTeamId{ get; set; }
        [Display(Name = "Time")]
        public int AjaxAvailableTimeSloteId { get; set; }
        public int AjaxAvailableTimeSloteIdEdit { get; set; }
        [Display(Name = "Provider")]
        public int AjaxDoctorByTeamIdQuick { get; set; }
        public int AjaxDoctorByTeamIdEdit { get; set; }
        public DateTime AjaxDate { get; set; }
        public DateTime AjaxDateEdit { get; set; }
        public Clerick User { get; set; }

        #endregion
    }
}
