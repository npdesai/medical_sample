namespace Medical.Common
{
    public static class ApiRoute
    {
        #region Identity
        public static class Identity
        {
            public const string Login = "api/identity/login";
        }
        #endregion

        #region Patient
        public static class Patients
        {
            public const string AddPatient = "api/patient/add";
        }
        #endregion
    }
}
