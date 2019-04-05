#pragma config(Sensor, S1,TIR,sensorI2CCustom)


#define ARDUINO_ADDRESS 0x08
#define ARDUINO_PORT S1

char i2cScanDeviceMsg[10];



task main()
{
	char i2cScanPort = ARDUINO_PORT;
	while(true){
		sendI2CMsg(i2cScanPort, &i2cScanDeviceMsg[0], 8);
	}


}
