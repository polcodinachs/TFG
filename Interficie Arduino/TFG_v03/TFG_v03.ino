#include<Wire.h> // I2C library
#include <Servo.h>

///----------------------------------------------
///----------------------------------------------

int instruction[6] = {5,0,0,0,0,0};

void setup()
{
  Wire.begin(0x04); // set the slave address
  Wire.onRequest(requestEvent); // Sending information back to the NXT/EV3
  Wire.onReceive(receiveI2C); // Receiving information!
  
  // Debugging
  Serial.begin(9600);
    
}
//________________________________________________________________________________

String x;
void loop()
{
  x = Serial.readStringUntil('\n');
  delay(500);     
}

//________________________________________________________________________________
//________________________________________________________________________________
//________________________________________________________________________________

byte read_byte = 0x00;
int byte_count = 0;
String datosA;
String datosB;
String datosC;


// When data is received from NXT/EV3, this function is called.
void receiveI2C(int bytesIn)
{
  read_byte = bytesIn;
  byte_count = 0;
  while(1 < Wire.available()) // loop through all but the last
  {
    read_byte = Wire.read(); 
    instruction[byte_count] = read_byte;
    byte_count++;
  }

  switch (instruction[0]){
    case 1:
    datosA = String(instruction[0]) + "," + String(instruction[1]) + "," + String(instruction[2]) + "," + instruction[3] + "," + String(instruction[4]);
     Serial.println(datosA);
    break;

    case 2:
    datosB = String(instruction[0]) + "," + String(instruction[1]) + "," + String(instruction[2]) + "," + instruction[3] + "," + String(instruction[4]);
    Serial.println(datosB);
    break;

    case 3:
    datosC = String(instruction[0]) + "," + String(instruction[1]) + "," + String(instruction[2]) + "," + instruction[3] + "," + String(instruction[4]);
    Serial.println(datosC);
    break;
    
    }



  //Serial.println(x);
  int x = Wire.read(); 
  // Read the last dummy byte (has no meaning, but must read it)



  if( instruction[0] == 1 )  
  {
    if(instruction[2] == 0) 
    {
    }
    else                    
    {
    }
    
  }
  else if( instruction[0] == 2 )  
  {
    
  }
  else if( instruction[0] == 3 )  
  {
    if (instruction[2] !=0) {

    }else{
   
  } 
  
  if( instruction[0] == 4 )   {

    
    if ( instruction[2] == true )
    {

    }
    else
    {
    }
  }
   
}//end recieveI2C
}
//_________________________________________________________________________________

String getValue(String data, char separator, int index)
{
    int found = 0;
    int strIndex[] = { 0, -1 };
    int maxIndex = data.length() - 1;

    for (int i = 0; i <= maxIndex && found <= index; i++) {
        if (data.charAt(i) == separator || i == maxIndex) {
            found++;
            strIndex[0] = strIndex[1] + 1;
            strIndex[1] = (i == maxIndex) ? i+1 : i;
        }
    }
    return found > index ? data.substring(strIndex[0], strIndex[1]) : "";
}

   

void requestEvent()
{ 
    int menu = ((x.substring(0,1)).toInt());
    if(menu == 1) {
      int motor = ((x.substring(2,3)).toInt());
      int moviment = ((x.substring(4,5)).toInt());
      int velocitat = ((x.substring(6,8)).toInt());
      Wire.write(menu);
      Wire.write(motor);
      Wire.write(moviment);
      Wire.write(velocitat);
    } else if(menu == 2){
      int figura = ((x.substring(2,4)).toInt());
      Wire.write(menu);
      Wire.write(figura);
    }
}
