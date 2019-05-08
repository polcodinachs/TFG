#pragma config(Sensor, S1,     TIR,            sensorI2CCustom)
#pragma config(Sensor, S2,     Touch,          sensorEV3_Touch)
//*!!Code automatically generated by 'ROBOTC' configuration wizard               !!*//

#define ARDUINO_PORT S1
#define ARDUINO_ADRESS 0x08

byte mensajeI2C[22];
char respuestaI2C[20];
char lectura[10];

int battery;

float encoder[4];
char velocitat[4];
int sensor[4];

int msg_i2c(byte dir_arduino, int tam_mensaje, int tam_respuesta, ubyte byte0, ubyte byte1, long byte2, ubyte byte3, ubyte byte4)
{
	memset(respuestaI2C, 0, sizeof(respuestaI2C));
	tam_mensaje = tam_mensaje + 3;
	mensajeI2C[0] = tam_mensaje;
	mensajeI2C[1] = dir_arduino;

	mensajeI2C[2] = byte0;
	mensajeI2C[3] = byte1;
	mensajeI2C[4] = byte2;
	mensajeI2C[5] = byte3;
	mensajeI2C[6] = byte4;

	sendI2CMsg(S1, &mensajeI2C[0], tam_respuesta);
	wait1Msec(20);

	readI2CReply(ARDUINO_PORT, &respuestaI2C[0], tam_respuesta);

	int x = respuestaI2C[0];

	wait1Msec(35);
	return x;
}

//MANDAR DATOS EV3 -----I2C-----> ARDUINO
void mandar_datos(int motor, byte direccion, int dato1, long dato2, int dato3, char dato4)
{
	msg_i2c(direccion, 5, 5, motor, dato1, dato2, dato3, dato4);
}


//MOTOR A
void posicioInicial(){
	if(SensorValue[S2] == 1) { //Estem en la posicio
		respuestaI2C[0] = '4';
		stopMotor(motorA);
	} else if (SensorValue[S2] == 0) { //No estem en la posicio incial
		while(SensorValue[S2] == 0) {
			setMotor(motorA, -10);
			if(SensorValue[S2] == 1){
				stopMotor(motorA);
				encoder[0] = 0;
			}
		}
	}
}

task main()
{
	while(true)
	{

	//DECLARACIONS VELOCITATS
	velocitat[1] = motor[motorA];
	velocitat[2] = motor[motorB];
	velocitat[3] = motor[motorC];

	//DECLARACIONS SENSORS
	sensor[1] = SensorValue[S2];
	sensor[2] = SensorValue[S3];
	sensor[3] = SensorValue[S4];

	//DECLARACIONS ENCODERS
	encoder[1] = getMotorEncoder(motorA);
	encoder[2] = getMotorEncoder(motorB);
	encoder[3] = getMotorEncoder(motorC);

		//REBRE DADES EV3 <----I2C---- ARDUINO
		for(int i = 0; i <= 5; i++){
			lectura[i] = respuestaI2C[i];
		}

	//MOTOR A
		//ENVIAR DADES A ARDUINO MOTOR A
		for(int i = 1; i <= 3; i ++){
			mandar_datos(i, ARDUINO_ADRESS, sensor[i], encoder[i], velocitat[i], battery);
		}

		//LECTURA DE LA POSICIO DEL MOTOR A
		if(SensorValue[S2] == 1){
			resetMotorEncoder(motorA);
		} else if(SensorValue[S2] == 0){
			encoder[1] = getMotorEncoder(motorA);
		}

		//MOVIMENTS MANUALS A
		switch(respuestaI2C[0]){
			case 1:
				posicioInicial();
				break;
			case 2:
					motor[motorA] = respuestaI2C[1];
					break;
			case 3:
				motor[motorA] = -respuestaI2C[1];
				break;
			case 4:
				stopMotor(motorA);
				break;
		}


		//SEGURETAT MOTOR A
		if(encoder[1] >= 7400){
			resetMotorEncoder(motorA);
			stopMotor(motorA);
		} else if(motor[motorA] < 0) {
			if(SensorValue[S2] == 1){
				stopMotor(motorA);
			}
		}

		wait1Msec(100);
	}
}
