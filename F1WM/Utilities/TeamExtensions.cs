using F1WM.ApiModel;
using F1WM.DatabaseModel;

namespace F1WM.Utilities
{
	public static class TeamExtensions
	{
		public static Management GetManagementInfo(this Team team)
		{
			return new Management()
			{
				Founder = team.Founder.IgnoreEmpty() == null ? null : new PersonSummary()
				{
					FullName = team.Founder,
					Picture = team.FounderPicture.GetTeamImagePath()
				},
				FirstTeamPrincipal = team.FirstTeamPrincipal.IgnoreEmpty() == null ? null : new PersonSummary()
				{
					FullName = team.FirstTeamPrincipal,
					Picture = team.FirstTeamPrincipalPicture.GetTeamImagePath()
				},
				TeamPrincipal = team.TeamPrincipal.IgnoreEmpty() == null ? null : new PersonSummary()
				{
					FullName = team.TeamPrincipal,
					Picture = team.TeamPrincipalPicture.GetTeamImagePath()
				},
				TechnicalDirector = team.TechnicalDirector.IgnoreEmpty() == null ? null : new PersonSummary()
				{
					FullName = team.TechnicalDirector,
					Picture = team.TechnicalDirectorPicture.GetTeamImagePath()
				},
				EngineeringDirector = team.EngineeringDirector.IgnoreEmpty() == null ? null : new PersonSummary()
				{
					FullName = team.EngineeringDirector,
					Picture = team.EngineeringDirectorPicture.GetTeamImagePath()
				},
				OtherDirector = team.OtherDirector.IgnoreEmpty() == null ? null : new OtherPersonSummary()
				{
					FullName = team.OtherDirector,
					Picture = team.OtherDirectorPicture.GetTeamImagePath(),
					Occupation = team.OtherDirectorOccupation.Trim()
				}
			};
		}
	}
}
