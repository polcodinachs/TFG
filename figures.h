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
	//Angle de 120Ã
	moveMotorTarget(motorA, (cosDegrees(60)*2500), 17.5);
	moveMotorTarget(motorB, (sinDegrees(60)*2500), 30.31);
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Angle de 120Ã
	moveMotorTarget(motorA, (cosDegrees(60)*2500), -17.5);
	moveMotorTarget(motorB, (sinDegrees(60)*2500), 30.31);
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Base
	moveMotorTarget(motorA, 2500, -35);
	waitUntilMotorStop(motorA);
	wait1Msec(1000);
	//Angle de 120Ã
	moveMotorTarget(motorA, (cosDegrees(60)*2500), -17.5);
	moveMotorTarget(motorB, (sinDegrees(60)*2500), -30.31);
	waitUntilMotorStop(motorA);
	waitUntilMotorStop(motorB);
	wait1Msec(1000);
	//Angle de 120Ã
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
	//PosiciÃÂ
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
	//Es comenÃÂÃÂÃ�
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

//Lletra B
void lletraB() {
	for (int i = 1; i <= 1; i++) {
		moveMotorTarget(motorA,0, -35);
	 	moveMotorTarget(motorB,5168.13, 35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

		moveMotorTarget(motorA,2000, 35);
	 	moveMotorTarget(motorB,0, 35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

		float parRadi0= 1292.375;
		float parAngleFinal0 = 180;
		float parAngleInici0 = 270;
		cercle(parRadi0, parAngleFinal0, parAngleInici0);

		float parRadi1= 1292.375;
		float parAngleFinal1 = 180;
		float parAngleInici1 = 270;
		cercle(parRadi1, parAngleFinal1, parAngleInici1);

		moveMotorTarget(motorA,2000, -35);
		moveMotorTarget(motorB,0, 35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
	}
}

//Lletra C
void lletraC() {

	moveMotorTarget(motorA,516.831, 35);
 	moveMotorTarget(motorB,0, 35);
	waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

	for (int i = 1; i <= 1; i ++) {
		moveMotorTarget(motorA,2000, -35);
	 	moveMotorTarget(motorB,0, 35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

		float parRadi0= 2584.155;
		float parAngleFinal0 = 180;
		float parAngleInici0 = 90;
		cercle(parRadi0, parAngleFinal0, parAngleInici0);

		moveMotorTarget(motorA,2000, 35);
		moveMotorTarget(motorB,0, 35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

		moveMotorTarget(motorA,0, -35);
		moveMotorTarget(motorB,1250, -35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

		moveMotorTarget(motorA,2000, -35);
		moveMotorTarget(motorB,0, 35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

		float parRadi1= 1334.155;
		float parAngleFinal1 = -180;
		float parAngleInici1 = 270;
		cercle(parRadi1, parAngleFinal1, parAngleInici1);

		moveMotorTarget(motorA,2000, 35);
		moveMotorTarget(motorB,0, 35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

		moveMotorTarget(motorA,0, -35);
		moveMotorTarget(motorB,1250, -35);
		waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
	}
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
	wait1Msec(2000);
	playSound(soundBeepBeep);
  wait1Msec(1000);
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

//Cercle
void cercle(float radius, float sweepAngle, int startAngle){
	int sentitX, sentitY;
	float sweepAngle2 = abs(sweepAngle) / 10;
	float startAngle2;
	switch (startAngle) {
		case 270:
			startAngle2 = 18;
			break;
		case 0:
			startAngle2 = 27;
			break;
		case 90:
			startAngle2 = 1;
			break;
		case 180:
			startAngle2 = 9;
			break;
	}
	for(int i = startAngle2; i <= sweepAngle2; i++){
		moveMotorTarget(motorA, (cosDegrees(10*i) * radius), (cosDegrees(10*i)* sentitX * 50));
		moveMotorTarget(motorB, (sinDegrees(10*i) * radius), (sinDegrees(10*i)* sentitY * -50));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
		if(i == 36 || i == 72){
			moveMotorTarget(motorC, 5, 50);
		}
	}
}
