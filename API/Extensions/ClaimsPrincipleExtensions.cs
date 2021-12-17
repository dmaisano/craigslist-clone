namespace System.Security.Claims
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userId = -1;
            int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out userId);

            return userId;
        }
    }
}
