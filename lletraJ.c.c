#pragma config(Motor,  motorA,          MotorA,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorB,          MotorB,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorC,          MotorC,        tmotorEV3_Large, PIDControl, encoder)
#include <cercle.h>
task main() {
moveMotorTarget(motorA,0, 35);
 moveMotorTarget(motorB,3000, 35);
waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
wait1Msec(2000);
for (int i = 1; i <= 5; i ++) {
moveMotorTarget(motorA,1250, 35);
 moveMotorTarget(motorB,0, 35);
waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
wait1Msec(100);
long parRadi0= 1250;
long parAngleFinal0 = -180;
int parAngleInici0 = 180;
cercle(parRadi0, parAngleFinal0, parAngleInici0);
wait1Msec(100);
moveMotorTarget(motorA,0, -35);
 moveMotorTarget(motorB,3918.31, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
wait1Msec(100);
moveMotorTarget(motorA,1250, 35);
 moveMotorTarget(motorB,0, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
moveMotorTarget(motorA,0, -35);
 moveMotorTarget(motorB,3918.31, -35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
wait1Msec(100);
long parRadi1= 2500;
long parAngleFinal1 = 180;
int parAngleInici1 = 0;
cercle(parRadi1, parAngleFinal1, parAngleInici1);
wait1Msec(100);

moveMotorTarget(motorC, 10, 50);
waitUntilMotorStop(motorC);

} }
