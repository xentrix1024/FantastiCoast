# Fantasticoast
## Elevation Data Interpolation Tool
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

### Technical Notes
- Input: Grayscale heightmap (16-bit RAW or PNG).
- Output: Processed heightmap with interpolated elevations.
