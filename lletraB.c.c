#pragma config(Motor,  motorA,          MotorA,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorB,          MotorB,        tmotorEV3_Medium, PIDControl, encoder)
#pragma config(Motor,  motorC,          MotorC,        tmotorEV3_Large, PIDControl, encoder)
#include <cercle.h>
task main() {
moveMotorTarget(motorA,0, 35); 
 moveMotorTarget(motorB,0, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
for (int i = 1; i <= 1; i ++) {
moveMotorTarget(motorA,0, -35); 
 moveMotorTarget(motorB,5168.31, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
moveMotorTarget(motorA,2000, 35); 
 moveMotorTarget(motorB,0, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
long parRadi0= 1292.0775;
long parAngleFinal0 = 180;
int parAngleInici0 = 270;
cercle(parRadi0, parAngleFinal0, parAngleInici0);
long parRadi1= 1292.0775;
long parAngleFinal1 = 180;
int parAngleInici1 = 270;
cercle(parRadi1, parAngleFinal1, parAngleInici1);
moveMotorTarget(motorA,2000, -35); 
 moveMotorTarget(motorB,0, 35);

waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);
} }
