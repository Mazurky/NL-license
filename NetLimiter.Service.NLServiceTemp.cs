// asmlby at 0x06000174 0x0000C8C0 Offset: 0x0000AAC0
//00A4	ldc.r8	99999
//00AD	call	instance valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::AddDays(float64)
private void InitLicense()
{
	string licensePath = this.GetLicensePath();
	NLServiceTemp._logger.LogInformation("RegData path: {path}", new object[]
	{
		licensePath
	});
	RegData regData = null;
	if (File.Exists(licensePath))
	{
		string value = File.ReadAllText(licensePath);
		try
		{
			regData = JsonConvert.DeserializeObject<RegData>(value);
			this.VerifyRegData(regData, true);
		}
		catch (Exception exception)
		{
			regData = null;
			NLServiceTemp._logger.LogError(exception, "Failed to init existing license: {path}", new object[]
			{
				licensePath
			});
		}
	}
	if (regData != null)
	{
		this.License = new NLLicense(regData);
		NLServiceTemp._logger.LogInformation("License found: expiration={expiration}", new object[]
		{
			this.License.Expiration
		});
	}
	else
	{
		DateTime installTime = this.GetInstallTime();
		DateTime expiration = installTime.AddDays(99999.0);
		this.License = new NLLicense(expiration);
		NLServiceTemp._logger.LogInformation("License not found: expiration={expiration}, installTime={installTime}", new object[]
		{
			this.License.Expiration,
			installTime
		});
	}
	this.Callback.OnLicenseChange(this.License);
}
