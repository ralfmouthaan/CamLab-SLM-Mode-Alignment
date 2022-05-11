# CamLab-SLM-Mode-Alignment

Fine-alignment of holograms to optimise for coupling into propagation-invariant modes.

The modes are pre-calculated using Waveguide-FDFD, and corresponding holograms are calculated using Mode-Hologen-DS. The hologram corresponding to a given mode is displayed on the SLM, and the output fields are captured using off-axis holographic imaging. The overlap integral with the target mode is calculated to check the purity of coupling into the target mode. The overlap integral with other modes is checked to ensure that other modes are not coupled into.

Zernike polynomials are superimposed on the hologram to optimise coupling into the target mode. The off-axis holography crop parameters also be varied to ensure the output fields are appropriately captured. In all, the following parameters can be optimised:
- Hologram scale
- Hologram rotation
- Hologram offset (x and y)
- Hologram tilt (x and y)
- Hologram defocus
- Hologram astigmatism
- Output fields real space crop (x, y, width and height)
- Output fields inverse space crop (x, y, width and height)

The parameters above are optimised using the Nelder-Meade algorithm. A composite error metric is optimised for which ensures coupling into the target mode is maximised, and coupling into other modes is minimised.

It is assumed that the hologram has been coarsely aligned using CamLab-SLM-Manual-Alignment, and that the off-axis holography parameters have been approximately set using CamLab-OffAxisCamera-Setup.

The code needs some handholding to work. The user can select which parameters to optimise, and it is recommended that in the first instance the hologram offset and the hologram tilt are optimised for, as well as the output field crop in real space and the output field crop in inverse space. It is also recommended that in the first instance only a few low-order modes are considered.
