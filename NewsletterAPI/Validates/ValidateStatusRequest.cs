namespace NewsletterAPI.Validates
{
	public static class ValidateStatusRequest
	{
		public static string[] StatusValids { get; private set; } = { "ENVIADO", "RECEBIDO", "ERRO DE ENVIO"};
    }
}
