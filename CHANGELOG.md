# Changelog

## 2.0.0 (2018-12-30)

### ADDED

- Helper class that allows knowing the constellation corresponding to given coordinates.

## 1.97.0 (2018-11-24)

### UPDATED

- Report of modifications from AA+ v1.97 :
  - Updated the observed DeltaT values from http://toshi.nofs.navy.mil/ser7/deltat.data to 1st April 2018

_Note_ : As AA+ versions from 1.94 to 1.96 were C++ specific corrections, they were not reported to AA#.

## 1.93.3 (2018-04-08)

### FIXED

- Correction of the validation of the parameter "month" in the method DaysInMonth in the class AASDate

## 1.93.2 (2018-03-06)

### FIXED

- Corrections in AASMoslemCalendar, results were not correct

## 1.93.1 (2018-03-06)

### ADDED

- License information

## 1.93 (2018-03-06)

### FIXED

- Report of correction from AA+ v1.93 :
  - Fixed a transcription bug in the AASPrecession.PrecessEquatorial method. The "0.017998tcubed" term was incorrectly using "0.017988tcubed" when calculating "sigma".

## 1.92 (2018-03-05)

- The whole library has been updated from AA+