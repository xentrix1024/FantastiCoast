# FantastiCoast
# Elevation Data Interpolation Tool
FantastiCoast is a utility designed to fill in missing elevation data in maps generated from Digital Elevation Model (DEM) sources. It interpolates neighboring elevations, ensuring smooth transitions between existing and missing data for a more natural-looking and usable heightmap.

It is particularly useful for coastal and water body elevations, which are often absent or incomplete in raw DEM datasets.

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

### Supported input file formats
- ASCII DEM files
- 24/32bit bmp
- 24/32bit png
- 16bit grayscale png
- 8bit grayscale png (low detail)
Undefined areas (missing elevation data) must have a value of 0 and will be represented as black pixels.

### Output file formats
- 24bit color bmp
- 24bit color png
- 16bit grayscale png
- 8bit grayscale png

🚫 Note: **Never use JPG for mapping purposes**, as it introduces compression artifacts.

## Usage
### Click Open to select your map file
The color scheme may be confusing but it allows for the display of up to 16million elevation steps.

Black pixels represent undefined elevation.

### Configure your settings
Adjust the sea bottom depth, minimum slope and maximum slope to fine-tune the interpolation strength.

### Click Launch to fill in the missing elevation data
The app will analyze neighboring areas and generate plausible elevation values.

This method is known as interpolation. It creates fictional elevation data to provide a complete terrain.

The smoothness of the terrain will depend on your selected settings.

### Review and export
Save the refined heightmap in your desired format.

FantastiCoast is a practical tool for refining elevation data, particularly in cases where DEM datasets contain missing or undefined regions. Whether for gaming, GIS applications, or scientific modeling, it provides a simple yet effective way to generate a complete heightmap.

⚠ Warning: Interpolation is a heuristic process and does not necessarily reflect real-world topography. It generates estimated elevation data based on surrounding values. Results may vary depending on input quality, the extent of missing data, and user configuration.
