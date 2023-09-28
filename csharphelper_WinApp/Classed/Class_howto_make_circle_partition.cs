
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

  namespace  howto_make_circle_partition

 { 

class RegionInfo
    {
        public Region Region;
        public int Count;

        // Make the RegionInfo for a circle.
        public RegionInfo(int count, PointF center, float radius)
        {
            Count = count;

            // Make the Region.
            using (GraphicsPath circle_path = new GraphicsPath())
            {
                circle_path.AddEllipse(
                    center.X - radius, center.Y - radius,
                    2 * radius, 2 * radius);
                Region = new Region(circle_path);
            }
        }

        // Make a RegionInfo for a Region.
        public RegionInfo(int count, Region region)
        {
            // Save the count and region.
            Count = count;
            Region = region;
        }

        // For each RegionInfo "other" in the list, intersect
        // "this" RegionInfo with other and make up to 3
        // new RegionInfos:
        //
        //      this - other
        //      other - this
        //      this intersect other
        //
        // We assume that we are not yet on the list.
        public void MakeIntersections(Graphics gr, List<RegionInfo> region_infos)
        {
            // Make a list to hold the new RegionInfos.
            List<RegionInfo> new_regioninfos = new List<RegionInfo>();

            // Intersect with the RegionInfos on the list.
            foreach (RegionInfo other in region_infos)
            {
                // Find this intersect other.
                Region intersection = this.Region.Clone();
                intersection.Intersect(other.Region);

                // See if the intersection is empty.
                if (intersection.IsEmpty(gr))
                {
                    // The intersection is empty. 
                    // Keep this and other as they are.
                    intersection.Dispose();
                }
                else
                {
                    // The intersection is not empty.
                    // Replace other with other - this.
                    other.Region.Xor(intersection);

                    // Replace this with this - other.
                    this.Region.Xor(intersection);

                    // Add the intersection to the new list.
                    new_regioninfos.Add(
                        new RegionInfo(this.Count + other.Count, intersection));
                }
            }

            // Add the new RegionInfos to the original list.
            foreach (RegionInfo new_regioninfo in new_regioninfos)
            {
                region_infos.Add(new_regioninfo);
            }
        }

        // Return the centroid of the region.
        private PointF RegionCentroid(Region region, Matrix transform)
        {
            float mx = 0;
            float my = 0;
            float total_weight = 0;
            foreach (RectangleF rect in region.GetRegionScans(transform))
            {
                float rect_weight = rect.Width * rect.Height;
                mx += rect_weight * (rect.Left + rect.Width / 2f);
                my += rect_weight * (rect.Top + rect.Height / 2f);
                total_weight += rect_weight;
            }

            return new PointF(mx / total_weight, my / total_weight);
        }

        // Draw the Region with the count at its centroid.
        public void Draw(Graphics gr, Font font, int max_count)
        {
            // See what color to use.
            int g = (int)(255 * Count / max_count);
            Color fill_color = Color.FromArgb(255, 0, g, 255);

            // Fill the Region.
            using (Brush fill_brush = new SolidBrush(fill_color))
            {
                gr.FillRegion(fill_brush, Region);
            }

            // Draw the count.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                gr.DrawString(Count.ToString(), font, Brushes.Black,
                    RegionCentroid(Region,gr.Transform), string_format);
            }
        }
    }

}