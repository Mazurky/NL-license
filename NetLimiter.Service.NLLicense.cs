// asmlby at 0x0600031B 0x00010AEC Offset: 0x0000ECEC
public NLLicense()
{
	this.Expiration = DateTime.MaxValue;
	this.EditionId = "pro";
	this.Quantity = 1;
	this.IsRegistered = true;
	this.IsRecurring = false;
	this.SupporetedFeatures = new SupportedFeatures(this.EditionId);
	this.InitTestingVersion();
}
