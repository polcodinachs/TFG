//Cercle
void cercle(float radius, float sweepAngle, int startAngle){
	int sentitX, sentitY;
	float sweepAngle2 = abs(sweepAngle) / 10;
	float startAngle2;
	switch (startAngle) {
		case 270:
			startAngle2 = 18;
			if (sweepAngle > 0) {
				sentitX = -1;
				sentitY = -1;
			} else {
				sentitX = 1;
				sentitY = -1;
			}
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
