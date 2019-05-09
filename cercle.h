void cercle(long radius, long sweepAngle, int startAngle){
	int sentitX, sentitY, sweepAngle2, startAngle2;
	sweepAngle2 = ceil(abs(sweepAngle) / 10);
	switch (startAngle) {
		case 270:
			startAngle2 = 18;
			if (sweepAngle > 0) {
				sentitX = -1;
				sentitY = 1;
			} else {
				sentitX = 1;
				sentitY = 1;
			}
			break;
		case 0:
			startAngle2 = 27;
			if (sweepAngle > 0) {
				sentitX = -1;
				sentitY = 1;
			} else {
				sentitX = -1;
				sentitY = -1;
			}
			break;
		case 90:
			startAngle2 = 1;
			if (sweepAngle > 0) {
				sentitX = -1;
				sentitY = 1;
			} else {
				sentitX = 1;
				sentitY = 1;
			}
			break;
		case 180:
			startAngle2 = 9;
			if (sweepAngle > 0) {
				sentitX = -1;
				sentitY = 1;
			} else {
				sentitX = -1;
				sentitY = -1;
			}
			break;
	}

	for(int i = startAngle2; i <= (startAngle2 + sweepAngle2); i++){
		moveMotorTarget(motorA, (cosDegrees(10*i) * radius / 6), (cosDegrees(10*i)* sentitX * 50));
		moveMotorTarget(motorB, (sinDegrees(10*i) * radius / 6), (sinDegrees(10*i)* sentitY * 50));
		waitUntilMotorStop(motorA);
		waitUntilMotorStop(motorB);
	}
}
