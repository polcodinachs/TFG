#pragma config(Sensor, S1,     TIR,            sensorI2CCustom)
#pragma config(Sensor, S2,     Touch1,         sensorEV3_Touch)
#pragma config(Sensor, S3,     Touch2,         sensorEV3_Touch)
#pragma config(Sensor, S4,     Touch3,         sensorEV3_Touch)
#pragma config(Motor,  motorA,          MotorA,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorB,          MotorB,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorC,          MotorC,        tmotorEV3_Large, PIDControl, encoder)
//*!!Code automatically generated by 'ROBOTC' configuration wizard               !!*//

//#include <KioskLibraries/VexIQ/ArmBot_Kiosk.c>

#include <Propies/cercle.h>

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


// POSICIO INICIAL MOTOR A
void posicioInicialA(){
	if(SensorValue[S2] == 1) { //Estem en la posicio
		respuestaI2C[0] = '4';
		stopMotor(motorA);
	} else if (SensorValue[S2] == 0) { //No estem en la posicio incial
		while(SensorValue[S2] == 0) {
			setMotor(motorA, -10);
			if(SensorValue[S2] == 1){
				stopMotor(motorA);
				encoder[1] = 0;
			}
		}
	}
}

// POSICIO INICIAL MOTOR B
void posicioInicialB(){
	if(SensorValue[S3] == 1) { //Estem en la posicio
		respuestaI2C[1] = '4';
		stopMotor(motorB);
	} else if (SensorValue[S3] == 0) { //No estem en la posicio incial
		while(SensorValue[S3] == 0) {
			setMotor(motorB, -10);
			if(SensorValue[S3] == 1){
				stopMotor(motorB);
				encoder[2] = 0;
			}
		}
	}
}


//QUADRAT
void quadrat() {
	int capes = 1;
	for(int i = 1; i <= capes; i++){
		moveMotorTarget(motorA, 3000, 40);
		waitUntilMotorStop(motorA);
		sleep(100);
		moveMotorTarget(motorB, 3000, 60);
		waitUntilMotorStop(motorB);
		sleep(100);
		moveMotorTarget(motorA, 3000, -40);
		waitUntilMotorStop(motorA);
		sleep(100);
		moveMotorTarget(motorB, 3000, -60);
		waitUntilMotorStop(motorB);
		sleep(100);
		moveMotorTarget(motorC, 10, 10);
		sleep(100);
	}
}

//TRIANGLE
void triangle() {
	for(int i = 1; i <= 3; i++) {
		moveMotorTarget(motorA, 5000, 35);
		waitUntilMotorStop(motorA);
		wait1Msec(1000);
		moveMotorTarget(motorA, 2500, -35);
		moveMotorTarget(motorB, 2500, 35);
		waitUntilMotorStop(motorB);
		waitUntilMotorStop(motorA);
		wait1Msec(1000);
		moveMotorTarget(motorA, 2500, -35);
		moveMotorTarget(motorB, 2500, -35);
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
	}
}

//HEXAGON
void hexagon() {
	moveMotorTarget(motorA, 3000, 35); //Situem en la posicio inicial per aquesta figura
	waitUntilMotorStop(motorA);
	wait1Msec(2000);
	for (int i = 1; i <= 3; i++) {
	moveMotorTarget(motorA, 2500, 35); //Base del poligon
	waitUntilMotorStop(motorA);
	wait1Msec(1000);
	//Angle de 120Ã
	moveMotorTarget(motorA, (cosDegrees(60)*2500), 17.5);
	moveMotorTarget(motorB, (sinDegrees(60)*2500), 30.31);
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Angle de 120Ã
	moveMotorTarget(motorA, (cosDegrees(60)*2500), -17.5);
	moveMotorTarget(motorB, (sinDegrees(60)*2500), 30.31);
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Base
	moveMotorTarget(motorA, 2500, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(1000);
	//Angle de 120Ã
	moveMotorTarget(motorA, (cosDegrees(60)*2500), -17.5);
	moveMotorTarget(motorB, (sinDegrees(60)*2500), -30.31);
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Angle de 120Ã
	moveMotorTarget(motorA, (cosDegrees(60)*2500), 17.5);
	moveMotorTarget(motorB, (sinDegrees(60)*2500), -30.31);
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	}
}

//PENTAGON
void pentagon() {
	//Posicio d'inici
	moveMotorTarget(motorA, 3000, 30);
	waitUntilMotorStop(motorA);
	wait1Msec(3000);
	for(int i = 1; i <= 3; i++){
		//Base
		moveMotorTarget(motorA, 2500, 35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);
		//Angle 72 +,+
		moveMotorTarget(motorA, (cosDegrees(72)*2500), (cosDegrees(72)*35));
		moveMotorTarget(motorB, (sinDegrees(72)*2500), (sinDegrees(72)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);
		//Angle 72 +,-
		moveMotorTarget(motorA, (sinDegrees(54)*2500), -(sinDegrees(54)*35));
		moveMotorTarget(motorB, (cosDegrees(54)*2500), (cosDegrees(54)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);
		//Angle 72 -,-
		moveMotorTarget(motorA, (cosDegrees(36)*2500), -(cosDegrees(36)*35));
		moveMotorTarget(motorB, (sinDegrees(36)*2500), -(sinDegrees(36)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);
		resetMotorEncoder(motorA);
		resetMotorEncoder(motorB);
		//Angle 72 +,-
		moveMotorTarget(motorA, (sinDegrees(18)*2500), (sinDegrees(18)*35));
		moveMotorTarget(motorB, (cosDegrees(18)*2500), -(cosDegrees(18)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorC, 5, 10);
		waitUntilMotorStop(motorC);
	}
}

//HEPTAGON
void heptagon() {
	//PosiciÃÂÃÂ
	moveMotorTarget(motorA, 3000, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(2000);
	//Base
	moveMotorTarget(motorA, 2500, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(1000);
	//Angle 52 +,+
	moveMotorTarget(motorA, (cosDegrees(51.43)*2500), (cosDegrees(51.43)*35));
	moveMotorTarget(motorB, (sinDegrees(51.43)*2500), (sinDegrees(51.43)*35));
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Angle 14 -,+
	moveMotorTarget(motorA, (sinDegrees(12.86)*2500), -(sinDegrees(12.86)*35));
	moveMotorTarget(motorB, (cosDegrees(12.86)*2500), (cosDegrees(12.86)*35));
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Angle 38 -,+
	moveMotorTarget(motorA, (sinDegrees(38.57)*2500), -(sinDegrees(38.57)*35));
	moveMotorTarget(motorB, (cosDegrees(38.57)*2500), (cosDegrees(38.57)*35));
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Angle 38 -,-
	moveMotorTarget(motorA, (sinDegrees(38)*2500), -(sinDegrees(38)*35));
	moveMotorTarget(motorB, (cosDegrees(38)*2500), -(cosDegrees(38)*35));
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
}

//Lletra A
void lletraA() {
	//Es comenÃÂÃÂÃÂÃÂÃ�
	//Angle de 70 +,+
	moveMotorTarget(motorA, (cosDegrees(70)*5500), (cosDegrees(70)*60));
	moveMotorTarget(motorB, (sinDegrees(70)*5500), (sinDegrees(70)*60));
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);

	//Base superior
	moveMotorTarget(motorA, 1800, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(1000);

	//Angle de 70 +,-
	moveMotorTarget(motorA, (cosDegrees(70)*5500), (cosDegrees(70)*60));
	moveMotorTarget(motorB, (sinDegrees(70)*5500), -(sinDegrees(70)*60));
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);

	//Base inferior dreta
	moveMotorTarget(motorA, 1418.08, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(1000);

	//Angle de 70 -,+
	moveMotorTarget(motorA, (cosDegrees(70)*1500), -(cosDegrees(70)*60));
	moveMotorTarget(motorB, (sinDegrees(70)*1500), (sinDegrees(70)*60));
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);

	//Base inferior central
	moveMotorTarget(motorA, 1700, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(1000);

	//Angle de 70 -,-
	moveMotorTarget(motorA, (cosDegrees(70)*1500), -(cosDegrees(70)*60));
	moveMotorTarget(motorB, (sinDegrees(70)*1500), -(sinDegrees(70)*60));
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);

	//Base inferior esquerra
	moveMotorTarget(motorA, 1418.08, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(1000);
}

//Lletra C
void lletraC() {
	//ComenÃÂÃÂÃÂÃÂÃÂ
	moveMotorTarget(motorB, 5168.31, 35);
	waitUntilMotorStop(motorB);
	wait1Msec(2000);

	moveMotorTarget(motorA, 5168.31, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(2000);

	moveMotorTarget(motorB, 1250, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(2000);

	moveMotorTarget(motorA, 3918.31, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(2000);

	moveMotorTarget(motorB, 2668.31, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(2000);

	moveMotorTarget(motorA, 3918.31, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(2000);

	moveMotorTarget(motorB, 1250, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(2000);

	moveMotorTarget(motorA, 5168.31, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(2000);
}

//Letra F
void lletraF() {
	moveMotorTarget(motorB, 5168.31, 35);
	waitUntilMotorStop(motorB);
	wait1Msec(200);

	moveMotorTarget(motorA, 4000, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(200);

	moveMotorTarget(motorB, 1000, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(200);

	moveMotorTarget(motorA, 2750, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(200);

	moveMotorTarget(motorB, 800, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(200);

	moveMotorTarget(motorA, 2750, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(200);

	moveMotorTarget(motorB, 1000, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(200);

	moveMotorTarget(motorA, 2750, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(200);

	moveMotorTarget(motorB, 2368.31, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(200);

	moveMotorTarget(motorA, 1250, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(200);
}

//Letra H
void lletraH() {
	for(int i = 1; i <= 2; i++) {
		int x;
		if(i == 1){x = 1;}else if(i == 2){x = -1;};
		moveMotorTarget(motorB, 5168.31, x*35);
		waitUntilMotorStop(motorB);
		wait1Msec(2000);

		moveMotorTarget(motorA, 1666.66, x*35);
		waitUntilMotorStop(motorA);
		wait1Msec(2000);

		moveMotorTarget(motorB, 2000, x*-35);
		waitUntilMotorStop(motorB);
		wait1Msec(2000);

		moveMotorTarget(motorA, 1666.66, x*35);
		waitUntilMotorStop(motorA);
		wait1Msec(2000);

		moveMotorTarget(motorB, 2000, x*35);
		waitUntilMotorStop(motorB);
		wait1Msec(2000);

		moveMotorTarget(motorA, 1666.66, x*35);
		waitUntilMotorStop(motorA);
		wait1Msec(2000);
	}
}

//Lletra I
void lletraI(){
	for(int i = 1; i <= 2; i++) {
		int x;
		if(i == 1){x = 1;}else if(i == 2){x = -1;};

		moveMotorTarget(motorB, 5168.31, x*35);
		waitUntilMotorStop(motorB);
		wait1Msec(2000);

		moveMotorTarget(motorA, 1666.66, x*35);
		waitUntilMotorStop(motorA);
		wait1Msec(2000);
	}
}

//Lletra K
void lletraK() {
	for(int i = 1; i <= 6; i++) {
		moveMotorTarget(motorB, 5168.31, 35);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, 35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);

		moveMotorTarget(motorB, 2000, -35);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, (sinDegrees(39.80)*35));
		moveMotorTarget(motorB, 2000, (cosDegrees(39.80)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, 35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);

		moveMotorTarget(motorA, 2500, -(sinDegrees(44.05)*35));
		moveMotorTarget(motorB, 2584.155, -(cosDegrees(44.05)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 2500, (cosDegrees(45.94)*35));
		moveMotorTarget(motorB, 2584.155, -(sinDegrees(45.94)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, -35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, -(cosDegrees(50.19)*35));
		moveMotorTarget(motorB, 2000, (sinDegrees(50.19)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorB, 2000, -35);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, -35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);

		moveMotorTarget(motorC, 5, 30);
		waitUntilMotorStop(motorC);
	}
}

//Lletra L
void lletraL() {
	moveMotorTarget(motorB, 5168.31, 35);
	waitUntilMotorStop(motorB);
	wait1Msec(2000);

	moveMotorTarget(motorA, 1666.66, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(2000);

	moveMotorTarget(motorB, 3501.65, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(2000);

	moveMotorTarget(motorA, 2333.34, 35);
	waitUntilMotorStop(motorA);
	wait1Msec(2000);

	moveMotorTarget(motorB, 1666.66, -35);
	waitUntilMotorStop(motorB);
	wait1Msec(2000);

	moveMotorTarget(motorA, 4000, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(2000);
}

//Lletra M
void lletraM() {
	for(int i = 1; i <= 4; i++){
		moveMotorTarget(motorB, 5168.31, 35);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, 35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);

		moveMotorTarget(motorA, 833.33, (sinDegrees(26.56)*35));
		moveMotorTarget(motorB, 1666.66, -(cosDegrees(26.56)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 833.33, (cosDegrees(63.43)*35));
		moveMotorTarget(motorB, 1666.66, (sinDegrees(63.43)*35));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, 35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);

		moveMotorTarget(motorB, 5163.31, -35);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, -35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);

		moveMotorTarget(motorB, 2668.32, 35);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 833.33, -35);
		moveMotorTarget(motorB, 833.33, -35);
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 833.33, -35);
		moveMotorTarget(motorB, 833.33, 35);
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorB, 2668.32, -35);
		waitUntilMotorStop(motorB);
		wait1Msec(200);

		moveMotorTarget(motorA, 1666.66, -35);
		waitUntilMotorStop(motorA);
		wait1Msec(200);

		moveMotorTarget(motorC, 5, 35);
		waitUntilMotorStop(motorC);
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

			//LECTURA DE LA POSICIO DEL MOTOR B
		if(SensorValue[S3] == 1){
			resetMotorEncoder(motorB);
		} else if(SensorValue[S3] == 0){
			encoder[2] = getMotorEncoder(motorB);
		}


		if(respuestaI2C[0] == 1){ //MOVIMENTS MANUALS
			if(respuestaI2C[1] == 1){ //MOTOR A
			switch(respuestaI2C[2]){
			case 1:
				posicioInicialA();
				break;
			case 2:
					motor[motorA] = respuestaI2C[3];
					break;
			case 3:
				motor[motorA] = -respuestaI2C[3];
				break;
			case 4:
				stopMotor(motorA);
				break;
			}
		} else if(respuestaI2C[1] == 2){ //MOTOR B
			switch(respuestaI2C[2]){
			case 1:
				posicioInicialB();
				break;
			case 2:
					motor[motorB] = respuestaI2C[3];
					break;
			case 3:
				motor[motorB] = -respuestaI2C[3];
				break;
			case 4:
				stopMotor(motorB);
				break;
			}
		} else if(respuestaI2C[1] == 3) {
			switch(respuestaI2C[2]){
			case 1:
				//posicioInicialC();
				break;
			case 2:
					motor[motorC] = respuestaI2C[3];
					break;
			case 3:
				motor[motorC] = -respuestaI2C[3];
				break;
			case 4:
				stopMotor(motorC);
				break;
			}
		}
	} else if (respuestaI2C[0] == 2) { //DISSENY DE FIGURES
		switch (respuestaI2C[1]) {
			case 10:
				quadrat();
				break;
			case 11:
				triangle();
				break;
			case 12:
				pentagon();
				break;
			case 13:
				hexagon();
				break;
			case 14:
				heptagon();
				break;
			case 15:
				lletraA();
				break;
			case 17:
				lletraC();
				break;
			case 18:
				lletraF();
				break;
			case 19:
				lletraH();
				break;
			case 20:
				lletraI();
				break;
			case 21:
				lletraK();
				break;
			case 22:
				lletraL();
				break;
			case 23:
				lletraM();
				break;
			case 24:
				cercle(1000.00, 36.00, 1);
				break;
		}
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

		//SEGURETAT MOTOR C
		if(encoder[3]*-1 >= 7800){
			resetMotorEncoder(motorC);
			stopMotor(motorC);
		} else if(motor[motorC] < 0) {
			if(SensorValue[S4] == 1){
				stopMotor(motorC);
			}
		}

		//SEGURETAT MOTOR B
		if(encoder[2]*-1 >= 7800){
			resetMotorEncoder(motorB);
			stopMotor(motorB);
		} else if(motor[motorB] < 0) {
			if(SensorValue[S3] == 1){
				stopMotor(motorB);
			}
		}
		wait1Msec(100);
	}
}
