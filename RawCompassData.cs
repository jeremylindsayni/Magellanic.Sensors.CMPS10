namespace Magellanic.Sensors.CMPS10
{
    public class RawCompassData
    {
        public RawCompassData(byte[] rawDeviceData)
        {
            this.SoftwareVersion = rawDeviceData[0];

            this.BearingAsByte = rawDeviceData[1];

            this.BearingAsWord = rawDeviceData[2] << 8 | rawDeviceData[3];

            this.PitchAngle = rawDeviceData[4];

            this.RollAngle = rawDeviceData[5];
        }

        public byte SoftwareVersion { get; private set; }

        public byte BearingAsByte { get; private set; }

        public int BearingAsWord { get; private set; }

        public byte PitchAngle { get; private set; }

        public byte RollAngle { get; private set; }
    }
}
