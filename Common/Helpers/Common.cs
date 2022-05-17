namespace Common.Helpers
{
    public static class Common
    {

        public static string GetComputerId()
        {
            return Network.GetMacAddress() ?? "NA";
        }
    }
}
