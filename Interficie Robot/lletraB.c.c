#pragma config(Motor,  motorA,          MotorA,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorB,          MotorB,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorC,          MotorC,        tmotorEV3_Large, PIDControl, encoder)
#include <cercle.h>
task main() {
moveMotorTarget(motorA,0, 35);
 moveMotorTarget(motorB,0, 35);
waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
for (int i = 0; i < 1; i ++) {
moveMotorTarget(motorA,0, -35);
 moveMotorTarget(motorB,5168.31, 35);
waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
moveMotorTarget(motorA,2000, 35);
 moveMotorTarget(motorB,0, 35);
waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);

float parRadi0= 1292.0775;
long parAngleFinal0 = 180;
long parAngleInici0 = 270;
cercle(parRadi0, parAngleFinal0, parAngleInici0);

float parRadi1= 1292.0775;
float parAngleFinal1 = 180;
float parAngleInici1 = 270;
cercle(parRadi1, parAngleFinal1, parAngleInici1);
moveMotorTarget(motorA,2000, -35);
 moveMotorTarget(motorB,0, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
} }
