(*** hide ***)
#I "../../bin"
#r @"MSNumpressFSharp\net47\MSNumpressFSharp.dll"
open MSNumpressFSharp

(** 
##Important! First read the documentation for Encoding. The output of the encoding function is used in the decoding function.

###Numpress Pic

The decodePic function takes the byteArrayPic with the encoded bytes, the output of encodePic, which is 
the number of encoded bytes and an empty float array with at least as many items as the original array.
The function modifies the float array and returns the number of decoded floats.
*)

let decodedDataPic: float[] = Array.zeroCreate 100

let decodePic = MSNumpressFSharp.Decode.decodePic (byteArrayPic, encodePic, decodedDataPic)

(**
decodedDataPic now contains the decoded floats.

###NumpressLin

The decodeLinear function takes the byteArrayLin with the encoded bytes, the output of encodeLin, which is 
the number of encoded bytes and an empty float array with at least as many items as the original array.
The function modifies the float array and returns the number of decoded floats.
*)

let decodedDataLin: float[] = Array.zeroCreate 100

let decodeLin = MSNumpressFSharp.Decode.decodeLinear (byteArrayLin, encodeLin, decodedDataLin)

(**
decodedDataLin now contains the decoded floats.

###NumpressSlof

The decodeSlof function takes the byteArraySlof with the encoded bytes, the output of encodeLin, which is 
the number of encoded bytes and an empty float array with at least as many items as the original array.
The function modifies the float array and returns the number of decoded floats.
*)

let decodedDataSlof: float[] = Array.zeroCreate 100

let decodeLin = MSNumpressFSharp.Decode.decodeLinear (byteArraySlof, encodeSlof, decodedDataSlof)

(**
decodedDataSlof now contains the decoded floats.
*)