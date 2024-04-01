import pytesseract
import PIL
from PIL import Image
from glob import glob
import os
from os import path
import csv

def process_image(img):
    img = Image.open(img)
    data = img.crop((0, 15, 270, 205))
    text = pytesseract.image_to_string(data) 
    data = [1, 2, 3, 4, 5, 6, 7, 8]
    img = img.crop((600, 300, 1200, 800))
    return img, data

def process(args):
    files = glob(path.join(args.path, "*.png"))
    print(f"{len(files)} images found.")

    os.mkdir(path.join(args.path, 'processed'))
    data_file = open(path.join(args.path, 'processed/data.csv'), 'w', newline='')
    field_names = ['clipID', 'frame', 'x_rotation', 'y_rotation', 'z_rotation', 'distance', 'x_pixel', 'y_pixel']
    writer = csv.DictWriter(data_file, fieldnames=field_names)
    writer.writeheader()
    for f in files:
        img, data = process_image(f)
        # img.save(path.join(args.path, f"processed/{data[0]}.png"))
        writer.writerow({field_names[i]: data[i] for i in range(8)})

if __name__ == '__main__':
    import argparse
    parser = argparse.ArgumentParser()
    parser.add_argument('--path')
    args = parser.parse_args()
    process(args)