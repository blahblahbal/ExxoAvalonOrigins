# Small python script to help with moving files into sorted directories
# May come in handy later for other things

import os
import re

def main():
    confirm = input("Use custom regex for batch selection ([Y]es/[N]o): ").lower()
    path = "./"
    if confirm == "" or confirm[0] == 'y':
        while True:
            x = input("Regex: ")
            moveItems(path, [item for item in os.listdir(path) if os.path.isfile(item) and re.search(x, item) and item.endswith(".cs")])
    else:
        for item in os.listdir(path):
            if os.path.isfile(item) and item.endswith(".cs"):
                moveItem(path, item)

def moveItem(basePath, item):
    f = open(basePath + item, "r")

    lines = f.readlines()
    for i in range(len(lines)):
        lines[i] = re.sub("ExxoAvalonOrigins.getDims\(.*\)", "this.GetDims()", lines[i])
        print(lines[i].strip("\n"))


    f.close()

    print(f"File name: {item}")
    path = basePath
    while (True):
        folders = [i for i in os.listdir(path) if os.path.isdir(path + i)]
        if len(folders) < 1:
            break

        for i in range(len(folders)):
            print(f"{i + 1}) {folders[i]}")

        try:
            choice = int(input()) - 1
            path += folders[choice] + "/"
        except IndexError:
            continue

    baseName = item.replace(".cs", "")
    filesToMove = [i for i in os.listdir(basePath) if re.search(f"^{baseName}(_.*.png|.png)", i)]
    filesToMove.append(item)



    print("The following items will be moved: ")
    for i in filesToMove:
        print(i)
    print(f"{basePath} -> {path}")
    confirm = input("Confirm ([Y]es/[N]o): ").lower()
    if confirm == "" or confirm[0] == 'y':
        f = open(basePath + item, "w")
        f.writelines(lines)
        f.close()
        for file in filesToMove:
            os.rename(basePath + file, path + file)

def moveItems(basePath, items):
    filesToMove = []
    for item in items:
        for i in os.listdir(basePath):
            baseName = item.replace(".cs", "")
            if re.search(f"^{baseName}(_.*.png|.png)", i):
                filesToMove.append(i)
        filesToMove.append(item)

    print("The following items will be moved: ")
    for i in filesToMove:
        print(i)

    path = basePath
    while (True):
        folders = [i for i in os.listdir(path) if os.path.isdir(path + i)]
        if len(folders) < 1:
            break

        for i in range(len(folders)):
            print(f"{i + 1}) {folders[i]}")

        try:
            choice = int(input()) - 1
            path += folders[choice] + "/"
        except IndexError:
            continue

    print("The following items will be moved: ")
    for i in filesToMove:
        print(i)
    print(f"{basePath} -> {path}")

    confirm = input("Confirm ([Y]es/[N]o): ").lower()
    if confirm == "" or confirm[0] == 'y':
        for item in items:
            f = open(basePath + item, "r")

            lines = f.readlines()
            for i in range(len(lines)):
                lines[i] = re.sub("ExxoAvalonOrigins.getDims\(.*\)", "this.GetDims()", lines[i])


            f.close()

            f = open(basePath + item, "w")
            f.writelines(lines)
            f.close()

        for file in filesToMove:
            os.rename(basePath + file, path + file)

if __name__ == '__main__':
    main()