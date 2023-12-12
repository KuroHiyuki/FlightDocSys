
using Microsoft.AspNetCore.Identity;

namespace FlightDocSys.Authentication
{
    public static class RoleBase
    {
        public const string Admin = "Administrator";
        public const string BackOffice = "Back Office GO";
        public const string Pilot = "Pilot";
        public const string Crew = "Crew";
    }
}
