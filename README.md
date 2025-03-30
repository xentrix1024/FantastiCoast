# FantastiCoast
# Elevation Data Interpolation Tool
Fantasticoast is a utility designed to fill missing elevation data in maps generated from Digital Elevation Model (DEM) sources. It interpolates coastal and water body elevations, ensuring smooth transitions between land and water for a more accurate and usable heightmap.

While originally developed for terrain generation in SimCity 4, the tool can be applied to other mapping and elevation modeling tasks where DEM-derived data requires refinement.

### Key Features
- Processes raw DEM-based heightmaps to fill gaps in elevation data.
- Generates smooth transitions between land and water bodies.
- Adjustable parameters for coastline blending and elevation smoothing.
- Outputs a refined heightmap suitable for further processing or visualization.

### Use Cases
- Terrain generation for simulations, games, or geographic modeling.
- Improving DEM-derived elevation data for hydrological studies.
- Enhancing elevation maps for 3D rendering or GIS applications.

### Acceptable input files
- ascii DEM files
- 24/32bit bmp
- 24/32bit png
- 16 bit grayscale png
- 8bit grayscale png (low detail)
Undefined areas (missing elevation data) will have a value of 0 and will be presented as black pixels.

### Output file types
- 24bit color bmp
- 24bit color png
- 16bit grayscale png
- 8bit grayscale png

**Never use jpg for mapping purposes**

## Usage
### Click Open to select your map
The color scheme might be confusing but it is one way to display up to 16million elevation steps.

Black pixels represent undefined elevation.

### Configure your settings
You can select the sea bottom depth and minimum & maximum slope

### Click Launch to fill in the gaps
The app will try to fill in the missing data by examining the neighboring areas and figuring out a possible elevation.

This method is called interpolation and it creates **fictional** data.

The smoothness of the ground will depend on your configuration settings.
