require 'date'

build_number = DateTime.now.strftime("%Y%m%d%H%M")
branch = 'local'

text = File.read("scripts/version.template.json")
new_contents = text.gsub(/<build_number>/, build_number).gsub(/<branch>/, branch)
File.open("version.json", "w") {|file| file.puts new_contents }