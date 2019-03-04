(*** hide ***)
#I "../../bin"
#r @"MSNumpressFSharp\net47\MSNumpressFSharp.dll"
open MSNumpressFSharp

(** 

###Numpress Pic 

This compression algorithm is intended for ion count data. 
It rounds values to the nearest integer, and stores these integers in a truncated 
form which is effective for values relatively close to zero. 

The encodePic function takes an array with data, the length of this array and a byte array
where the encoded bytes are stored. The maximum size of the byte array is n * 5, 
but usually it is smaller depending on the data. The function modifies the byte array and returns 
the number of encoded bytes.
*)

//sample data
let dataPic = [|1. .. 100.|]

//empty array for the encoded bytes
let byteArrayPic: byte[] = Array.zeroCreate (dataPic.Length * 5)

//takes data, data length and an empty array for the encoded bytes. Returns the number of encoded bytes.
let encodePic = MSNumpressFSharp.Encode.encodePic (dataPic, dataPic.Length, byteArrayPic)

(**
byteArrayPic now contains the compressed data. The byte array and number of encoded bytes is needed for 
decoding.

###Numpress Lin

This compression uses a fixed point representation, achieved by multiplication with a scaling factor 
and rounding to the nearest integer. The algorithm is intended for m/z or retention time data. To exploit 
the assumed linearity of the data, linear prediction is then used. 
The scaling factor can be chosen manually, but the library also contains a function for 
retrieving the optimal linear scaling factor for a given data array. Since the scaling factor is variable, 
it is stored as a regular double precision float first in the encoding, and automatically parsed during 
decoding.

The encodeLinear function takes an array with data, the length of this array, a byte array where the encoded bytes 
are stored and a linear scaling factor. The maximum size of the byte array is 8 + n * 5, 
but usually it is smaller depending on the data. The function modifies the byte array and returns 
the number of encoded bytes.
*)

//sample data
let dataLin = [|1. .. 100.|]

//empty array for the encoded bytes
let byteArrayLin: byte[] = Array.zeroCreate (8 + dataLin.Length * 5)

//optimal scaling factor for sample data
let optimalFixedPointLin = MSNumpressFSharp.Encode.optimalLinearFixedPoint (dataLin, dataLin.Length)

//takes data, data length, an empty array for the encoded bytes and a scaling factor. Returns the number of encoded bytes.
let encodeLin = MSNumpressFSharp.Encode.encodeLinear (dataLin, dataLin.Length, byteArrayLin, optimalFixedPointLin)

(**
byteArrayLin now contains the compressed data. The byte array and number of encoded bytes is needed for 
decoding.

###Numpress Slof

This function also targets ion count data. The compression takes the natural logarithm of values, multiplies it 
by a scaling factor and rounds to the nearest integer. For typical ion count dynamic ranges these 
values fits into two byte integers, so only the two least significant bytes of the integer are stored. 
The scaling factor can be chosen manually, but the library also contains a function for retrieving 
the optimal Slof scaling factor for a given data array. Since the scaling factor is variable, it is 
stored as a regular double precision float first in the encoding, and automatically parsed during 
decoding.

The encodeSlof function takes an array with data, the length of this array, a byte array where the encoded bytes 
are stored and a linear scaling factor.The maximum size of the byte array is n * 2 + 8, 
but usually it is smaller depending on the data. The function modifies the byte array and returns 
the number of encoded bytes.
*)

//sample data
let dataSlof = [|1. .. 100.|]

//empty array for the encoded bytes
let byteArraySlof: byte[] = Array.zeroCreate (8 + dataSlof.Length * 2)

//optimal scaling factor for sample data
let optimalFixedPointSlof = MSNumpressFSharp.Encode.optimalSlofFixedPoint (dataSlof, dataSlof.Length)

//takes data, data length, an empty array for the encoded bytes and a scaling factor. Returns the number of encoded bytes.
let encodeSlof = MSNumpressFSharp.Encode.encodeSlof (dataSlof, dataSlof.Length, byteArraySlof, optimalFixedPointSlof)

(**
byteArrayLin now contains the compressed data. The byte array and number of encoded bytes is needed for 
decoding.
*)