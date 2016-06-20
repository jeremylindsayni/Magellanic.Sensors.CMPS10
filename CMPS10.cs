using Magellanic.I2C;
using System;
using System.Threading.Tasks;

namespace Magellanic.Sensors.CMPS10
{
    public class CMPS10 : AbstractI2CDevice
    {
        private byte I2C_ADDRESS = 0x60;

        public override byte[] GetDeviceId()
        {
            throw new NotImplementedException();
        }

        public override byte GetI2cAddress()
        {
            return I2C_ADDRESS;
        }

        public RawCompassData GetCompassData()
        {
            byte[] readBuffer = new byte[6];

            this.Slave.WriteRead(new byte[] { 0x00 }, readBuffer);

            return new RawCompassData(readBuffer);
        }

        public void RestoreFactorySettings()
        {
            this.Slave.Write(new byte[] { 0x16, 0x20 });
            Task.Delay(100).Wait();
            this.Slave.Write(new byte[] { 0x16, 0x2A });
            Task.Delay(100).Wait();
            this.Slave.Write(new byte[] { 0x16, 0x60 });
        }

        public void StartCalibration()
        {
            this.Slave.Write(new byte[] { 0x16, 0xF0 });
        }

        public void CalibrateOrdinalCompassPoint()
        {
            this.Slave.Write(new byte[] { 0x16, 0xF5 });
        }
    }
}
