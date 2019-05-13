#pragma config(Motor,  motorA,          MotorA,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorB,          MotorB,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorC,          MotorC,        tmotorEV3_Large, PIDControl, encoder)
#include <cercle.h>
task main() {
moveMotorTarget(motorA,5500, 35);
 moveMotorTarget(motorB,0, 35);
waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
wait1Msec(2000);
for (int i = 1; i <= 4; i ++) {
moveMotorTarget(motorA,2000, -35);
 moveMotorTarget(motorB,0, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
long parRadi0= 2584.155;
long parAngleFinal0 = 180;
int parAngleInici0 = 90;
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
long parRadi1= 1334.155;
long parAngleFinal1 = -180;
int parAngleInici1 = 270;
cercle(parRadi1, parAngleFinal1, parAngleInici1);
moveMotorTarget(motorA,2000, 35);
 moveMotorTarget(motorB,0, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
moveMotorTarget(motorA,0, -35);
 moveMotorTarget(motorB,1250, -35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

moveMotorTarget(motorC, 10, 50);
waitUntilMotorStop(motorC);
} }
